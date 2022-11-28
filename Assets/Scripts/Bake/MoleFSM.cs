using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ͽ� ���, ���� ���, ����->���� �̵�, ����->���� �̵�
public enum MoleState {UnderGround = 0, OnGround, MoveUp, MoveDown}

public class MoleFSM : MonoBehaviour
{
    [SerializeField]
    private float waitTimeOnGround; // ���鿡 �ö�ͼ� ����������� ��ٸ��� �ð�
    [SerializeField]
    private float limitMinY;    // ������ �� �ִ� �ּ� y ��ġ
    [SerializeField]
    private float limitMaxY;    // �ö�� �� �ִ� �ּ� y ��ġ

    private Movement movement3D;  // ��/�Ʒ� �̵��� ���� Movement3D

    private MoleSpawner moleSpawner;

    // �δ����� ���� ���� (set�� MoleFSM Ŭ���� ���ο�����)
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
        // ������ ������ ToString() �޼ҵ带 �̿��� ���ڿ��� ��ȯ�ϸ�
        // "UnderGround"�� ���� ������ ��� �̸� ��ȯ

        // ������ ��� ���̴� ���� ����
        StopCoroutine(MoleState.ToString());
        // ���� ����
        MoleState = newState;
        // ���ο� ���� ���
        StartCoroutine(MoleState.ToString());
    }

    // �δ����� �ٴڿ��� ����ϴ� ���·� ���ʿ� �ٴ� ��ġ�� �δ��� ��ġ ����
    private IEnumerator UnderGround()
    {
        // �̵� ������ : (0, 0, 0) [����]
        movement3D.MoveTo(Vector3.zero);
        // �δ����� y��ġ�� Ȧ�� �����ִ� limitMinY ��ġ�� ����
        transform.position = new Vector3(transform.position.x, limitMinY, transform.position.z);

        yield return null;
    }

    // �δ����� Ȧ ������ �����ִ� ���·� waitTimeOnGround���� ���
    private IEnumerator OnGround()
    {
        // �̵� ������ : (0, 0, 0) [����]
        movement3D.MoveTo(Vector3.zero);
        // �δ����� y��ġ�� Ȧ ������ �����ִ� limitMaxY ��ġ�� ����
        transform.position = new Vector3(transform.position.x, limitMaxY, transform.position.z);

        // waitTimeOnGround �ð� ���� ���
        yield return new WaitForSeconds(waitTimeOnGround);

        // �δ��� ���¸� MoveDown���� ����
        ChangeState(MoleState.MoveDown);
    }

    // �δ����� Ȧ ������ ������ ����(maxYPosOnGround ��ġ���� ���� �̵�)
    private IEnumerator MoveUp()
    {
        // �̵� ������ : (0, 1, 0) [��]
        movement3D.MoveTo(Vector3.up);

        while(true)
        {
            // �δ����� y ��ġ�� limitMaxY�� �����ϸ� ���� ����
            if(transform.position.y >= limitMaxY)
            {
                // OnGround ���·� ����
                ChangeState(MoleState.OnGround);
            }

            yield return null;
        }
    }

    // �δ����� Ȧ�� ���� ����(minYPosUnderGround ��ġ���� �Ʒ��� �̵�)
    private IEnumerator MoveDown()
    {
        // �̵� ������ : (0, -1, 0) [�Ʒ�]
        movement3D.MoveTo(Vector3.down);

        moleSpawner.spawnCount++;

        while(true)
        {
            // �δ����� y ��ġ�� limitMinY�� �����ϸ� �ݺ��� ����
            if(transform.position.y <= limitMinY)
            {
                // UnderGround ���·� ����
                ChangeState(MoleState.UnderGround);
            }

            yield return null;
        }
    }
}
