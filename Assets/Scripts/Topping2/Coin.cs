using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private GameObject coinEffectPrefab;
    private float rotateSpeed = 1;


    private void Awake()
    {
        rotateSpeed = Random.Range(0, 360); // ������ ����
    }
    
    void Update()
    {
        // ���� ������Ʈ ȸ��
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ������Ʈ ȹ�� ȿ�� (coinEffectPrefab) ����
        GameObject clone = Instantiate(coinEffectPrefab);
        clone.transform.position = transform.position;

        // ���� ������Ʈ ����
        Destroy(gameObject);
    }
}
