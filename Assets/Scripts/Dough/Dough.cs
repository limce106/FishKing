using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dough : MonoBehaviour
{
    public float gameTime; // �ð�
    public int spaceCount = 0; //�����̽��� ���� Ƚ��
    string doughGrade = ""; // ���� �ϼ���

    public Text timeText; // �ð� �ؽ�Ʈ
    public Text spaceCountText; // ���� Ƚ�� �ؽ�Ʈ
    public Text doughGradeText; // ���� �ϼ��� �ؽ�Ʈ

    public TotalGrade totalGrade;

    // private bool isGameOver = false;

    private void Awake()
    {
        gameTime = 10f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Debug.Log("�����̽��� ����");
            Debug.Log(spaceCount);
            spaceCount++;
            spaceCountText.text = "���� Ƚ�� : " + spaceCount;

            Vector3 vec = new Vector3(0, 0, -0.1f);
            transform.Translate(vec);
        }

        if (gameTime > 0)
            gameTime -= Time.deltaTime;

        timeText.text = "�ð� : " + Mathf.Ceil(gameTime).ToString();


        
        // ���� ���϶�
        if (gameTime > 0 && gameTime <= 10f)
        {
            if (gameTime > 0)
                gameTime -= Time.deltaTime;

                timeText.text = "�ð� : " + Mathf.Ceil(gameTime).ToString();
        }
        else // ���� ���� �� ��
        {
            totalGrade.PrintGrade();
        }
        
    }


}