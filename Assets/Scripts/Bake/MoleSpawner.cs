using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private MoleFSM[] moles;    // �ʿ� �����ϴ� �δ�����
    [SerializeField]
    private float spawnTime;    // �δ��� ���� �ֱ�
    public int spawnCount = 0;     // �δ��� ���� Ƚ��
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
        // ������ 1�̰� ��� �δ����� ���Դٸ�
        if(SingleTon.Instance.level == 1 && spawnCount == 15)
        {
            // ��� �ڷ�ƾ�� ���߰� ��� ���
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
