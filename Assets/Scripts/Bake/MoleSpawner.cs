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
    public TotalGrade totalGrade;
    void Start()
    {
        StartCoroutine("SpawnMole");
    }

    private void Update() 
    {
        AllMolesUp();
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

    private void AllMolesUp()
    {
        // 레벨이 1이고 모든 두더지가 나왔다면
        if(SingleTon.Instance.level == 1 && spawnCount == 15)
        {
            // 모든 코루틴을 멈추고 등급 계산
            StopAllCoroutines();
            totalGrade.PrintGrade();
        }

        else if(SingleTon.Instance.level == 2 && spawnCount == 20)
        {
            StopAllCoroutines();
            totalGrade.PrintGrade();
        }

        else if(SingleTon.Instance.level == 3 && spawnCount == 25)
        {
            StopAllCoroutines();
            totalGrade.PrintGrade();
        }

        else if(SingleTon.Instance.level == 4 && spawnCount == 30)
        {
            StopAllCoroutines();
            totalGrade.PrintGrade();
        }

        else if(SingleTon.Instance.level == 5 && spawnCount == 35)
        {
            StopAllCoroutines();
            totalGrade.PrintGrade();
        }
    }
}
