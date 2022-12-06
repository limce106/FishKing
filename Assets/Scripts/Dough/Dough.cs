using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dough : MonoBehaviour
{
    public float gameTime; // �ð�
    public int spaceCount = 0; //�����̽��� ���� Ƚ��
    // string doughGrade = ""; // ���� �ϼ���

    public Text timeText; // �ð� �ؽ�Ʈ
    public Text spaceCountText; // ���� Ƚ�� �ؽ�Ʈ
    public Text doughGradeText; // ���� �ϼ��� �ؽ�Ʈ

    public TotalGrade totalGrade;

    // private bool isGameOver = false;

    private void Awake()
    {
        if(SingleTon.Instance.level == 1)
        {
            gameTime = 20f;
        }
        else if (SingleTon.Instance.level == 2)
        {
            gameTime = 15f;
        }
        else if (SingleTon.Instance.level == 3)
        {
            gameTime = 10f;
        }
        else if (SingleTon.Instance.level == 4)
        {
            gameTime = 7f;
        }
        else if (SingleTon.Instance.level == 5)
        {
            gameTime = 5f;
        }
    }

    void Start()
    {
        //isGameOver = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) == true && Time.timeScale == 1)
        {
            if(gameTime > 0)
            {
                Debug.Log("�����̽��� ����");
                Debug.Log(spaceCount);
                spaceCount++;
                spaceCountText.text = "���� Ƚ�� : " + spaceCount;

                Vector3 vec = new Vector3(0, 0, -0.1f);
                transform.Translate(vec);
            }
        }

        if (gameTime > 0)
            gameTime -= Time.deltaTime;

        timeText.text = "�ð� : " + Mathf.Ceil(gameTime).ToString();
        
        // ���� ���϶�
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            timeText.text = "�ð� : " + Mathf.Ceil(gameTime).ToString();
        }
        else // ���� ���� �� ��
        {
            totalGrade.PrintGrade();
        }
        
    }


}