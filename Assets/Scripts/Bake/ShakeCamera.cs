using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private static ShakeCamera instance;
    // �ܺο��� Get ���ٸ� �����ϵ��� Instance ������Ƽ ����
    public static ShakeCamera Instance => instance;

    // ī�޶� ��鸲 ���� �ð�(�������� ������ ����Ʈ 1.0f)
    private float shakeTime;
    // ī�޶� ��鸲 ����(�������� ������ ����Ʈ 0.1f)
    private float shakeIntensity;

    // ������ ������ �� ī�޶� �ڽ��� ������ instance ������ ����
    public ShakeCamera()
    {
        instance = this;
    }

    // �ܺο��� ī�޶� ��鸲�� ������ �� ȣ���ϴ� �޼ҵ�
    // ex) OnShakeCamera(1); => 1�ʰ� 0.1�� ����� ��鸲
    // ex) OnShakeCamera(0.5f, 1); => 0.5�ʰ� 1�� ����� ��鸲
    public void OnShakeCamera(float shakeTime=1.0f, float shakeIntensity = 1.2f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StartCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    // ī�޶� shakeTime���� shakeIntensity�� ����� ���� �ڷ�ƾ
    private IEnumerator ShakeByPosition()
    {
        // ��鸮�� ������ ���� ��ġ(��鸲 ���� �� ���ƿ� ��ġ)
        Vector3 startPosition = transform.position;

        while(shakeTime > 0.0f)
        {
            // �ʱ� ��ġ�κ��� �� ���� * shakeIntensity ���� �ȿ��� ī�޶� ��ġ ����
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            // �ð� ����
            shakeTime -= Time.deltaTime;

            yield return null;
        }
        transform.position = startPosition;
    }
}
