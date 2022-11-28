using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDectector : MonoBehaviour
{
    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { }   // 이벤트 클래스 정의
                                                            // 등록되는 이벤트 메소드는 Transform 매개변수 1개를 가지는 메소드
    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();  // 이벤트 클래스 인스턴스 생성 및 메모리 할당

    private Camera mainCamera;   // 광선을 생성하기 위한 Camera
    private Ray ray;            // 생성된 광선 정보를 저장하기 위한 Ray
    private RaycastHit hit;     // 광선에 부딪힌 오브젝트 정보 저장을 위한 RaycastHit

    private void Awake() 
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if(Input.GetMouseButtonDown(0))
        {
            // 카메라 위치에서 화면의 마우스 위치를 관통하는 광선 생성
            // ray.origin : 광선의 시작위치(=카메라 위치)
            // ray.direction : 광선의 진행방향
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                raycastEvent.Invoke(hit.transform);
            }
        }
    }
}
