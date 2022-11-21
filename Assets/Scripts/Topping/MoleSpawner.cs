using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private MoleFSM[] moles;    // �ʿ� �����ϴ� �δ�����
    [SerializeField]
    private float spawnTime;    // �δ��� ���� �ֱ�
    void Start()
    {
        StartCoroutine("SpawnMole");
    }

    private IEnumerator SpawnMole()
    {
        while(true)
        {
            int index = Random.Range(0, moles.Length);
            moles[index].ChangeState(MoleState.MoveUp);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
