using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지하에 대기, 지상에 대기, 지하->지상 이동, 지상->지하 이동
public enum MoleState {UnderGround = 0, OnGround, MoveUp, MoveDown}

public class MoleFSM : MonoBehaviour
{
    [SerializeField]
    private float waitTimeOnGround; // 지면에 올라와서 내려가기까지 기다리는 시간
    [SerializeField]
    private float limitMinY;    // 내려갈 수 있는 최소 y 위치
    [SerializeField]
    private float limitMaxY;    // 올라올 수 있는 최소 y 위치

    private Movement movement3D;  // 위/아래 이동을 위한 Movement3D

    private MoleSpawner moleSpawner;

    // 두더지의 현재 상태 (set은 MoleFSM 클래스 내부에서만)
    public MoleState MoleState {private set; get;}

    private void Awake() 
    {
        movement3D = GetComponent<Movement>();
        moleSpawner = GameObject.Find("MoleSpawner").GetComponent<MoleSpawner>();
        ChangeState(MoleState.UnderGround);
    }

    void Update() 
    {
        if(SingleTon.Instance.level == 1)
        {
            waitTimeOnGround = 0.8f;
        }

        else if(SingleTon.Instance.level == 2)
        {
            waitTimeOnGround = 0.7f;
        }

        else if(SingleTon.Instance.level == 3)
        {
            waitTimeOnGround = 0.6f;
        }

        else if(SingleTon.Instance.level == 4)
        {
            waitTimeOnGround = 0.5f;
        }

        else if(SingleTon.Instance.level == 5)
        {
            waitTimeOnGround = 0.4f;
        }
    }

    public void ChangeState(MoleState newState)
    {
        // 열거형 변수를 ToString() 메소드를 이용해 문자열로 변환하면
        // "UnderGround"와 같이 열거형 요소 이름 변환

        // 이전에 재생 중이던 상태 종료
        StopCoroutine(MoleState.ToString());
        // 상태 변경
        MoleState = newState;
        // 새로운 상태 재생
        StartCoroutine(MoleState.ToString());
    }

    // 두더지가 바닥에서 대기하는 상태로 최초에 바닥 위치로 두더지 위치 설정
    private IEnumerator UnderGround()
    {
        // 이동 방향을 : (0, 0, 0) [정지]
        movement3D.MoveTo(Vector3.zero);
        // 두더지의 y위치를 홀에 숨어있는 limitMinY 위치로 설정
        transform.position = new Vector3(transform.position.x, limitMinY, transform.position.z);

        yield return null;
    }

    // 두더지가 홀 밖으로 나와있는 상태로 waitTimeOnGround동안 대기
    private IEnumerator OnGround()
    {
        // 이동 방향을 : (0, 0, 0) [정지]
        movement3D.MoveTo(Vector3.zero);
        // 두더지의 y위치를 홀 밖으로 나와있는 limitMaxY 위치로 설정
        transform.position = new Vector3(transform.position.x, limitMaxY, transform.position.z);

        // waitTimeOnGround 시간 동안 대기
        yield return new WaitForSeconds(waitTimeOnGround);

        // 두더지 상태를 MoveDown으로 변경
        ChangeState(MoleState.MoveDown);
    }

    // 두더지가 홀 밖으로 나오는 상태(maxYPosOnGround 위치까지 위로 이동)
    private IEnumerator MoveUp()
    {
        // 이동 방향을 : (0, 1, 0) [위]
        movement3D.MoveTo(Vector3.up);

        moleSpawner.spawnCount++;
        Debug.Log(moleSpawner.spawnCount);

        while(true)
        {
            // 두더지의 y 위치가 limitMaxY에 도달하면 상태 변경
            if(transform.position.y >= limitMaxY)
            {
                // OnGround 상태로 변경
                ChangeState(MoleState.OnGround);
            }

            yield return null;
        }
    }

    // 두더지가 홀로 들어가는 상태(minYPosUnderGround 위치까지 아래로 이동)
    private IEnumerator MoveDown()
    {
        // 이동 방향을 : (0, -1, 0) [아래]
        movement3D.MoveTo(Vector3.down);

        while(true)
        {
            // 두더지의 y 위치가 limitMinY에 도달하면 반복문 중지
            if(transform.position.y <= limitMinY)
            {
                // UnderGround 상태로 변경
                ChangeState(MoleState.UnderGround);
            }

            yield return null;
        }
    }
}
