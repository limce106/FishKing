using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 拳搁俊辑 荤扼柳 备开 昏力, 货肺款 备开 积己
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

    void Update()
    {
        if( playerTransform.position.z - transform.position.z >= destroyDistance )
        {
            // 货肺款 备开 积己
            areaSpawner.SpawnArea();
            // 泅犁 备开篮 昏力
            Destroy(gameObject);
        }
    }
}
