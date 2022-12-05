using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private ToppingGC gameController; // ++ IsGameStart�� true�� �� �����̱� ����


    // x�� �̵�
    private float moveXWidth = 1.5f; // 1ȸ �̵� �� �̵� �Ÿ� (x��)
    private float moveTimeX = 0.1f; // 1ȸ �̵��� �ҿ�Ǵ� �ð� (x��)
    private bool isXMove = false; // true : �̵� ��, false : �̵�
                                  
    // y�� �̵�
    private float originY = 0.55f; // ���� �� �����ϴ� y�� ��
    private float gravity = -9.81f; // �߷�
    private float moveTimeY = 0.3f; // 1ȸ �̵��� �ҿ�Ǵ� �ð� (y��)
    private bool isJump = false; // true : ���� ��, false : ���� ����

    // z�� �̵�
    public float moveSpeed; // �̵� �ӵ�(z��)

    // ȸ��
    [SerializeField]
    private float rotateSpeed = 300.0f; // ȸ�� �ӵ�

    private float limitY = -1.0f; // �÷��̾ ������� �� y�� ��ġ

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
        //++ ���� ���°� ���� ������ �ƴϸ� Update()�� �������� ����.
        if (gameController.IsGameStart == false) return;


        // z�� �̵�
        transform.position += (Vector3.forward * moveSpeed * Time.deltaTime);
        
        // ������Ʈ ȸ�� (x��)
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);

        // ���������� �������� �÷��̾� ���
        if( transform.position.y < limitY)
        {
            Debug.Log("���ӿ���");
            gameController.GameOver();
        }
    }

    // �ܺο��� x�� �̵��� �� �� ȣ���ϴ� �޼ҵ�
    // �Ű����� x : 1 �Ǵ� -1
    public void MoveToX(int x)
    {
        // ���� x�� �̵� ������ �̵� �Ұ���
        if (isXMove == true) return;

        // x�� 0���� Ŭ ��, �÷��̾��� ��ġ�� ���� �Ǵ� ����̸�
        if( x > 0 && transform.position.x < moveXWidth)
        {
            StartCoroutine(OnMoveToX(x)); // ������ �̵� ����
        }
        // x�� 0���� ���� ��, �÷��̾��� ��ġ�� ������ �Ǵ� ����̸�
        else if ( x < 0 && transform.position.x > -moveXWidth )
        {
            StartCoroutine(OnMoveToX(x)); // ���� �̵� ����
        }
    }


    // �ܺο��� y�� �̵��� �� �� ȣ���ϴ� �Լ�
    public void MoveToY()
    {
        // ���� ���� ������ ���� �Ұ���
        if (isJump == true) return;

        StartCoroutine(OnMoveToY());
    }

    // moveTimeX�ð����� ���� ��ġ start���� end��ŭ x������ �̵�
    private IEnumerator OnMoveToX(int direction)
    {
        float current = 0;
        float percent = 0;
        float start = transform.position.x;
        float end = transform.position.x + direction * moveXWidth;

        isXMove = true; // �̵��� ������ �� isXMove�� true�� ����

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeX;

            float x = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            yield return null;
        }

        isXMove = false; // �̵��� ������ �� isXMove�� false�� ����
    }

    // moveTimeY�ð����� y�� �������� ����
    private IEnumerator OnMoveToY()
    {
        float current = 0;
        float percent = 0;
        float v0 = -gravity; // y������ �ʱ� �ӵ�

        isJump = true;
        rigidbody.useGravity = false; // ������ ������ �� �߷��� ���� ����

        while( percent < 1 )
        {
            current += Time.deltaTime;
            percent = current / moveTimeY;

            // �ð� ����� ���� ������Ʈ�� y��ġ�� �ٲ���
            // ������ � : ���� ��ġ + �ʱ� �ӵ� * �ð� + �߷� * �ð�����
            float y = originY + (v0 * percent) + (gravity * percent * percent);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            yield return null;
        }

        isJump = false; // �����ϴ� ���� ������ �� ������
        rigidbody.useGravity = true; // �ٴڿ� �����ϸ� �߷��� ����
    }

}
