using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 화면에서 사라진 구역 삭제, 새로운 구역 생성 (플레이어와의 거리를 비교하여)
public class Area : MonoBehaviour
{
    [SerializeField]
    private float destroyDistance = 15;
    private AreaSpawner areaSpawner;
    private Transform playerTransform;

   public void Setup(AreaSpawner areaSpawner, Transform playerTransform)
    {
        this.areaSpawner = areaSpawner;
        this.playerTransform = playerTransform;
    }

    void Start()
    {
        // 플레이어와 바닥셀 하나의 거리 차이가 15가 넘으면
        if( playerTransform.position.z - transform.position.z >= destroyDistance )
        {
            // 새로운 구역 생성
            areaSpawner.SpawnArea();
            // 현재 구역은 삭제
            Destroy(gameObject);
        }
    }
}
