using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDectector : MonoBehaviour
{
    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }   // �̺�Ʈ Ŭ���� ����
                                                            // ��ϵǴ� �̺�Ʈ �޼ҵ�� Transform �Ű����� 1���� ������ �޼ҵ�
    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();  // �̺�Ʈ Ŭ���� �ν��Ͻ� ���� �� �޸� �Ҵ�

    private Camera mainCamera;   // ������ �����ϱ� ���� Camera
    private Ray ray;            // ������ ���� ������ �����ϱ� ���� Ray
    private RaycastHit hit;     // ������ �ε��� ������Ʈ ���� ������ ���� RaycastHit

    private void Awake() 
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if(Input.GetMouseButtonDown(0))
        {
            // ī�޶� ��ġ���� ȭ���� ���콺 ��ġ�� �����ϴ� ���� ����
            // ray.origin : ������ ������ġ(=ī�޶� ��ġ)
            // ray.direction : ������ �������
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                raycastEvent.Invoke(hit.transform);
            }
        }
    }
}
