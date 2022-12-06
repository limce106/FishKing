using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon : MonoBehaviour
{

    // ���� ���� �����ϱ� ���� �̱��� ��ũ��Ʈ
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

    // ����
    public int level = 1;

    // ��ȭ
    public int coin = 0;

    // ���������� ����
    public string sab1;
    public string sab2;
    public string sab3;

    // ���� ����
    public int totalScore;
}
