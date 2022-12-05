using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private ToppingGC gameController; // ++ IsGameStart가 true일 때 움직이기 위해


    // x축 이동
    private float moveXWidth = 1.5f; // 1회 이동 시 이동 거리 (x축)
    private float moveTimeX = 0.1f; // 1회 이동에 소요되는 시간 (x축)
    private bool isXMove = false; // true : 이동 중, false : 이동
                                  
    // y축 이동
    private float originY = 0.55f; // 점프 및 착지하는 y축 값
    private float gravity = -9.81f; // 중력
    private float moveTimeY = 0.3f; // 1회 이동에 소요되는 시간 (y축)
    private bool isJump = false; // true : 점프 중, false : 점프 가능

    // z축 이동
    public float moveSpeed; // 이동 속도(z축)

    // 회전
    [SerializeField]
    private float rotateSpeed = 300.0f; // 회전 속도

    private float limitY = -1.0f; // 플레이어가 사망했을 때 y의 위치

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        if(SingleTon.Instance.level == 1)
        {
            moveSpeed = 10f;
        }
        else if (SingleTon.Instance.level == 2)
        {
            moveSpeed = 12f;
        }
        else if (SingleTon.Instance.level == 3)
        {
            moveSpeed = 14f;
        }
        else if (SingleTon.Instance.level == 4)
        {
            moveSpeed = 16f;
        }
        else if (SingleTon.Instance.level == 5)
        {
            moveSpeed = 18f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //++ 현재 상태가 게임 시작이 아니면 Update()를 실행하지 않음.
        if (gameController.IsGameStart == false) return;


        // z축 이동
        transform.position += (Vector3.forward * moveSpeed * Time.deltaTime);
        
        // 오브젝트 회전 (x축)
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);

        // 낭떠러지로 떨어지면 플레이어 사망
        if( transform.position.y < limitY)
        {
            Debug.Log("게임오버");
            gameController.GameOver();
        }
    }

    // 외부에서 x축 이동을 할 때 호출하는 메소드
    // 매개변수 x : 1 또는 -1
    public void MoveToX(int x)
    {
        // 현재 x축 이동 중으로 이동 불가능
        if (isXMove == true) return;

        // x가 0보다 클 때, 플레이어의 위치가 왼쪽 또는 가운데이면
        if( x > 0 && transform.position.x < moveXWidth)
        {
            StartCoroutine(OnMoveToX(x)); // 오른쪽 이동 가능
        }
        // x가 0보다 작을 때, 플레이어의 위치가 오른쪽 또는 가운데이면
        else if ( x < 0 && transform.position.x > -moveXWidth )
        {
            StartCoroutine(OnMoveToX(x)); // 왼쪽 이동 가능
        }
    }


    // 외부에서 y축 이동을 할 때 호출하는 함수
    public void MoveToY()
    {
        // 현재 점프 중으로 점프 불가능
        if (isJump == true) return;

        StartCoroutine(OnMoveToY());
    }

    // moveTimeX시간동안 현재 위치 start부터 end만큼 x축으로 이동
    private IEnumerator OnMoveToX(int direction)
    {
        float current = 0;
        float percent = 0;
        float start = transform.position.x;
        float end = transform.position.x + direction * moveXWidth;

        isXMove = true; // 이동을 시작할 때 isXMove를 true로 설정

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeX;

            float x = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            yield return null;
        }

        isXMove = false; // 이동을 종료할 때 isXMove를 false로 설정
    }

    // moveTimeY시간동안 y축 방향으로 점프
    private IEnumerator OnMoveToY()
    {
        float current = 0;
        float percent = 0;
        float v0 = -gravity; // y방향의 초기 속도

        isJump = true;
        rigidbody.useGravity = false; // 점프를 시작할 때 중력을 받지 않음

        while( percent < 1 )
        {
            current += Time.deltaTime;
            percent = current / moveTimeY;

            // 시간 경과에 따라 오브젝트의 y위치를 바꿔줌
            // 포물선 운동 : 시작 위치 + 초기 속도 * 시간 + 중력 * 시간제곱
            float y = originY + (v0 * percent) + (gravity * percent * percent);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            yield return null;
        }

        isJump = false; // 점프하는 동안 점프할 수 없도록
        rigidbody.useGravity = true; // 바닥에 착지하면 중력을 받음
    }

}
