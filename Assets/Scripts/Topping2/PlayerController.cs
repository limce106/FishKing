using System.Collections;
using UnityEngine;

// 터치 드레그로 플레이어의 행동을 제어
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float dragDistance = 50.0f; //드래그 거리
    private Vector3 touchStart; // 터치 시작 위치
    private Vector3 touchEnd; // 터치 종료 위치

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
        // 터치 시작
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }

        // 터치 & 드래그
        else if( Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            OnDragXY();
        }
    }

    private void OnDragXY()
    {
        // 터치 상태로 x축 드래그 범위가 dragDistance보다 클 때
        // x의 이동거리 : touchEnd.x - touchStart.x 
        if ( Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance )
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));
            audioSource.PlayOneShot(audioMove);
            return;
        }

        // 터치 상태로 y축 양의 방향으로 드래그 범위가 dragDistance보다 클 때
        if( touchEnd.y - touchStart.y >= dragDistance)
        {
            movement.MoveToY();
            audioSource.PlayOneShot(audioJump);
            return;
        }
    }

}
