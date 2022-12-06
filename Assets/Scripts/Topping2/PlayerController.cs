using System.Collections;
using UnityEngine;

// ��ġ �巹�׷� �÷��̾��� �ൿ�� ����
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float dragDistance = 50.0f; //�巡�� �Ÿ�
    private Vector3 touchStart; // ��ġ ���� ��ġ
    private Vector3 touchEnd; // ��ġ ���� ��ġ

    private Move movement;

    public AudioClip audioJump;
    public AudioClip audioMove;
    AudioSource audioSource;

    private void Awake()
    {
        movement = GetComponent<Move>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        OnPCPlatform();
    }

    private void OnPCPlatform()
    {
        // ��ġ ����
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }

        // ��ġ & �巡��
        else if( Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            OnDragXY();
        }
    }

    private void OnDragXY()
    {
        // ��ġ ���·� x�� �巡�� ������ dragDistance���� Ŭ ��
        // x�� �̵��Ÿ� : touchEnd.x - touchStart.x 
        if ( Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance )
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));
            audioSource.PlayOneShot(audioMove);
            return;
        }

        // ��ġ ���·� y�� ���� �������� �巡�� ������ dragDistance���� Ŭ ��
        if( touchEnd.y - touchStart.y >= dragDistance)
        {
            movement.MoveToY();
            audioSource.PlayOneShot(audioJump);
            return;
        }
    }

}
