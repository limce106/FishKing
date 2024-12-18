using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon : MonoBehaviour
{

    // 변수 값을 유지하기 위한 싱글톤 스크립트
    static SingleTon instance = null;
    public static SingleTon Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake() 
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 레벨
    public int level = 1;

    // 재화
    public int coin = 0;

    // 스테이지별 점수
    public string sab1;
    public string sab2;
    public string sab3;

    // 최종 점수
    public int totalScore;
}
