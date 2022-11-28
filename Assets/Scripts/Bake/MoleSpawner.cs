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

    private void Update() {
        // ������ 1�̰� ��� �δ����� ���Դٸ�
        if(SingleTon.Instance.level == 1 && spawnCount == 3)
        {
            // ��� �ڷ�ƾ�� ���߰� ��� ���
            StopAllCoroutines();
            totalGrade.PrintGrade();
        }

        // else if(SingleTon.Instance.level == 2 && spawnCount == 10)
        // {

        // }
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
