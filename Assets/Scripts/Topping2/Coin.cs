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
        rotateSpeed = Random.Range(0, 360); // 임의의 숫자
    }
    
    void Update()
    {
        // 코인 오브젝트 회전
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 코인 오브젝트 획득 효과 (coinEffectPrefab) 생성
        GameObject clone = Instantiate(coinEffectPrefab);
        clone.transform.position = transform.position;

        // 코인 오브젝트 삭제
        Destroy(gameObject);
    }
}
