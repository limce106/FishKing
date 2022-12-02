using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] areaPrefabs; //���� ������ �迭

    [SerializeField]
    private int spawnAreaCountAtStart = 5; // ���� ���� �� ���� �����Ǵ� ���� ����

    [SerializeField]
    private float zDistance = 20; // ���� ������ �Ÿ� (z)
    private int areaIndex = 0; // ���� �ε��� (��ġ�Ǵ� ������ z ��ġ ���꿡 ���)

    // ++
    [SerializeField]
    private Transform playerTransform; // �÷��̾� Transform


    private void Awake()
    {
        // spawnAreaCountAtStart�� ����� ������ŭ ���� ���� ����
        // ������ 3�� ����
        for(int i = 0; i < spawnAreaCountAtStart; ++i)
        {
            // ù ��° ������ �׻� 0�� ���� ���������� ����
            if(i==0)
            {
                SpawnArea(false);
            }
            else
            {
                SpawnArea();
            }
        }
    }

    public void SpawnArea(bool isRandom = true)
    {
        GameObject clone = null;

        if(isRandom == false)
        {
            clone = Instantiate(areaPrefabs[0]); // 0�� ������ ����
        }
        else
        {
            // ���� ��ϵǾ��ִ� ���� ������ �� ������ ������ ����
            int index = Random.Range(0, areaPrefabs.Length);
            clone = Instantiate(areaPrefabs[index]);
        }

        // ������ ��ġ�Ǵ� ��ġ ���� ( z���� ���� ���� �ε��� * zDistance)
        clone.transform.position = new Vector3(0, 0, areaIndex * zDistance);


        //++ ������ ������ �� ���ο� ������ ������ �� �ֵ��� this�� �÷��̾��� Transform ���� ����
        clone.GetComponent<Area>().Setup(this, playerTransform);

        areaIndex++; // zDistance��ŭ �� �������� ����
    }
}
