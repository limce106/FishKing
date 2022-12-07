using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    private float maxY; // ��ġ �ִ� y ��ġ
    [SerializeField]
    private float minY; // ��ġ �ּ� y ��ġ
    [SerializeField]
    private GameObject moleHitEffectPrefab; // �δ��� Ÿ�� ȿ�� ������
    [SerializeField]
    private ObjectDectector objectDectector;
    private Movement movement3D;
    public int hitCount = 0;   // �δ��� Ÿ�� Ƚ��

    public AudioClip audioHit;
    AudioSource audioSource;

    private void Awake() 
    {
        movement3D = GetComponent<Movement>();
        audioSource = this.gameObject.GetComponent<AudioSource>();

        // OnHit �޼ҵ带 ObjectDectector Ŭ������ raycastEvent�� �̺�Ʈ�� ���
        objectDectector.raycastEvent.AddListener(OnHit);
    }

    private void OnHit(Transform target)
    {
        if(target.CompareTag("Mole"))
        {
            MoleFSM mole = target.GetComponent<MoleFSM>();

            // �δ����� Ȧ �ȿ� ���� ���� ���� �Ұ�
            if(mole.MoleState == MoleState.UnderGround)
                return;
            
            // ��ġ ��ġ ����
            transform.position = new Vector3(target.position.x, minY, target.position.z);

            // ��ġ�� �¾����Ƿ� �δ��� ���¸� "UnderGround"�� ����
            mole.ChangeState(MoleState.UnderGround);

            // ī�޶� ����
            ShakeCamera.Instance.OnShakeCamera(0.1f, 0.1f);

            // �δ��� Ÿ�� ȿ�� ����(Particle�� ������ �δ��� ����� �����ϰ� ����)
            GameObject clone = Instantiate(moleHitEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = clone.GetComponent<ParticleSystem>().main;
            main.startColor = mole.GetComponent<MeshRenderer>().material.color;

            // �δ��� Ÿ�� Ƚ�� ����
            hitCount++;

            audioSource.PlayOneShot(audioHit);

            // ��ġ�� ���� �̵�
            StartCoroutine("MoveUp");
        }
    }

    private IEnumerator MoveUp()
    {
        // �̵� ����(0, 1, 0) [��]
        movement3D.MoveTo(Vector3.up);

        while(true)
        {
            if(transform.position.y >= maxY)
            {
                movement3D.MoveTo(Vector3.zero);
                break;
            }

            yield return null;
        }
    }
    
}