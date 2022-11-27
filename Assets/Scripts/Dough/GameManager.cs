using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameTime; // �ð�
    int spaceCount = 0; //�����̽��� ���� Ƚ��
    string doughGrade = ""; // ���� �ϼ���

    public Text timeText; // �ð� �ؽ�Ʈ
    public Text spaceCountText; // ���� Ƚ�� �ؽ�Ʈ
    public Text doughGradeText; // ���� �ϼ��� �ؽ�Ʈ

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
            // ���࿡ 10�ʾȿ� + spaceCount��
            // 30�� => s
            // 20�� => a
            // 15���̸� => b
            if (spaceCount >= 30)
            {
                doughGrade = "S";
                Debug.Log("S"); ;
            }
            else if (spaceCount >= 20)
            {
                doughGrade = "A";
                Debug.Log("A");
            }
            else
            {
                doughGrade = "B";
                Debug.Log("B");
             }

            doughGradeText.text = doughGrade + "��";
            // ��� ���̰� �ϱ�
            doughGradeText.gameObject.SetActive(true);

            Debug.Log("Gameover");
        }
        
    }


}