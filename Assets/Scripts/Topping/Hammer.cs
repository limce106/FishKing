using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    private float maxY; // 망치 최대 y 위치
    [SerializeField]
    private float minY; // 망치 최소 y 위치
    [SerializeField]
    private GameObject moleHitEffectPrefab; // 두더지 타격 효과 프리팹
    [SerializeField]
    private ObjectDectector objectDectector;
    private Movement movement3D;

    private void Awake() 
    {
        movement3D = GetComponent<Movement>();

        // OnHit 메소드를 ObjectDectector 클래스의 raycastEvent에 이벤트로 등록
        objectDectector.raycastEvent.AddListener(OnHit);
    }

    private void OnHit(Transform target)
    {
        if(target.CompareTag("Mole"))
        {
            MoleFSM mole = target.GetComponent<MoleFSM>();

            // 두더지가 홀 안에 있을 때는 공격 불가
            if(mole.MoleState == MoleState.UnderGround)
                return;
            
            // 망치 위치 설정
            transform.position = new Vector3(target.position.x, minY, target.position.z);

            // 망치에 맞았으므로 두더지 상태를 "UnderGround"로 설정
            mole.ChangeState(MoleState.UnderGround);

            // 카메라 흔들기
            ShakeCamera.Instance.OnShakeCamera(0.1f, 0.1f);

            // 두더지 타격 효과 생성(Particle의 색상을 두더지 색상과 동일하게 설정)
            GameObject clone = Instantiate(moleHitEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = clone.GetComponent<ParticleSystem>().main;
            main.startColor = mole.GetComponent<MeshRenderer>().material.color;

            // 망치를 위로 이동
            StartCoroutine("MoveUp");
        }
    }

    private IEnumerator MoveUp()
    {
        // 이동 방향(0, 1, 0) [위]
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