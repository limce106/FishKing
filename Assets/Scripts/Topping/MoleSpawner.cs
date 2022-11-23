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
    public ToppingGrade toppingGrade;
    void Start()
    {
        StartCoroutine("SpawnMole");
    }

    private void Update() {
        // ������ ~�̰� ��� �δ����� ���Դٸ�
        if(spawnCount == 2)
        {
            // ��� �ڷ�ƾ�� ���߰� ��� ���
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
