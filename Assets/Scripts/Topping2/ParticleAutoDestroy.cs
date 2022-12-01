using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������Ʈ ȹ��

// ���� ���ӿ����� ������Ʈ�� �ϳ��� ��ƼŬ�� ��� ��������
// ���� ���� ��ƼŬ�� �ϳ��� �׷����� ��� ����� ���� �ð��� ���� �� ��ƼŬ�� ��� ���θ� �˻��ϰų�
// ��ƼŬ ����� ����Ǿ ��ƼŬ�� �����Ǹ� �ȵ� ��쿡�� �ð��� �������� ����⵵ �Ѵ�.
public class ParticleAutoDestroy : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(particle.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
