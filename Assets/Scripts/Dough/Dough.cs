using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dough : MonoBehaviour
{
    public float gameTime; // 시간
    public int spaceCount = 0; //스페이스바 누른 횟수
    string doughGrade = ""; // 반죽 완성도

    public Text timeText; // 시간 텍스트
    public Text spaceCountText; // 누른 횟수 텍스트
    public Text doughGradeText; // 반죽 완성도 텍스트

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
        if (gameTime > 0 && gameTime <= 10f)
        {
            if (gameTime > 0)
                gameTime -= Time.deltaTime;

                timeText.text = "시간 : " + Mathf.Ceil(gameTime).ToString();
        }
        else // 게임 오버 일 때
        {
            totalGrade.PrintGrade();
        }
        
    }


}