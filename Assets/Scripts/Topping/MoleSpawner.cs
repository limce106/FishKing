using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private MoleFSM[] moles;    // 맵에 존재하는 두더지들
    [SerializeField]
    private float spawnTime;    // 두더지 등장 주기
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
