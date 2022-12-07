using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private static ShakeCamera instance;
    // 외부에서 Get 접근만 가능하도록 Instance 프로퍼티 선언
    public static ShakeCamera Instance => instance;

    // 카메라 흔들림 지속 시간(설정하지 않으면 디폴트 1.0f)
    private float shakeTime;
    // 카메라 흔들림 세기(설정하지 않으면 디폴트 0.1f)
    private float shakeIntensity;

    // 게임을 실행할 때 카메라 자신의 정보를 instance 변수에 저장
    public ShakeCamera()
    {
        instance = this;
    }

    // 외부에서 카메라 흔들림을 조작할 때 호출하는 메소드
    // ex) OnShakeCamera(1); => 1초간 0.1의 세기로 흔들림
    // ex) OnShakeCamera(0.5f, 1); => 0.5초간 1의 세기로 흔들림
    public void OnShakeCamera(float shakeTime=1.0f, float shakeIntensity = 1.2f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StartCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    // 카메라를 shakeTime동안 shakeIntensity의 세기로 흔드는 코루틴
    private IEnumerator ShakeByPosition()
    {
        // 흔들리기 직전의 시작 위치(흔들림 종료 후 돌아올 위치)
        Vector3 startPosition = transform.position;

        while(shakeTime > 0.0f)
        {
            // 초기 위치로부터 구 범위 * shakeIntensity 범위 안에서 카메라 위치 변동
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            // 시간 감소
            shakeTime -= Time.deltaTime;

            yield return null;
        }
        transform.position = startPosition;
    }
}
