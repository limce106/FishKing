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

    // Start is called before the first frame update
    private void Awake()
    {
        movement = GetComponent<Move>();
    }

    // Update is called once per frame
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
            return;
        }

        // ��ġ ���·� y�� ���� �������� �巡�� ������ dragDistance���� Ŭ ��
        if( touchEnd.y - touchStart.y >= dragDistance)
        {
            movement.MoveToY();
            return;
        }
    }

}