using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ȭ�鿡�� ����� ���� ����, ���ο� ���� ���� (�÷��̾���� �Ÿ��� ���Ͽ�)
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
        // �÷��̾�� �ٴڼ� �ϳ��� �Ÿ� ���̰� 15�� ������
        if( playerTransform.position.z - transform.position.z >= destroyDistance )
        {
            // ���ο� ���� ����
            areaSpawner.SpawnArea();
            // ���� ������ ����
            Destroy(gameObject);
        }
    }
}
