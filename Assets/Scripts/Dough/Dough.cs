using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dough : MonoBehaviour
{
    public float gameTime; // 시간
    public int spaceCount = 0; //스페이스바 누른 횟수
    // string doughGrade = ""; // 반죽 완성도

    public Text timeText; // 시간 텍스트
    public Text spaceCountText; // 누른 횟수 텍스트
    public Text doughGradeText; // 반죽 완성도 텍스트

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

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Debug.Log("스페이스바 누름");
            Debug.Log(spaceCount);
            spaceCount++;
            spaceCountText.text = "누른 횟수 : " + spaceCount;

            Vector3 vec = new Vector3(0, 0, -0.1f);
            transform.Translate(vec);
        }

        if (gameTime > 0)
            gameTime -= Time.deltaTime;

        timeText.text = "시간 : " + Mathf.Ceil(gameTime).ToString();
        
        // 게임 중일때
        if (gameTime > 0)
        {
            if (gameTime > 0)
                gameTime -= Time.deltaTime;

                timeText.text = "시간 : " + Mathf.Ceil(gameTime).ToString();
        }
        else // 게임 오버 일 때
        {
<<<<<<< Updated upstream:Assets/Scripts/Dough/Dough.cs
            totalGrade.PrintGrade();
=======
            // 만약에 10초안에 + spaceCount가
            // 30번 => s
            // 20번 => a
            // 15번이면 => b
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

            doughGradeText.text = doughGrade + "급";
            // 등급 보이게 하기
            doughGradeText.gameObject.SetActive(true);

            Debug.Log("Gameover");
>>>>>>> Stashed changes:Assets/Scripts/Dough/GameManager.cs
        }
        
    }


}