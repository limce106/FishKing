using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private MoleFSM[] moles;    // 맵에 존재하는 두더지들
    [SerializeField]
    private float spawnTime;    // 두더지 등장 주기
    public int spawnCount = 0;     // 두더지 등장 횟수
    public ToppingGrade toppingGrade;
    void Start()
    {
        StartCoroutine("SpawnMole");
    }

    private void Update() {
        // 레벨이 ~이고 모든 두더지가 나왔다면
        if(spawnCount == 2)
        {
            // 모든 코루틴을 멈추고 등급 계산
            StopAllCoroutines();
            toppingGrade.PrintGrade();
        }
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
