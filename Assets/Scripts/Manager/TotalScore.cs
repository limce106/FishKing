using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TotalScore : MonoBehaviour
{
    private TotalGrade tg;
    private int score1;
    private int score2;
    private int score3;
    private int totalScore;

    void Start()
    {
        tg = GetComponent<TotalGrade>();
    }

    void Update()
    {
        
    }

    void CalScore()
    {
        if(tg.sab1 == "S")
            score1 = 90;
        else if(tg.sab1 == "A")
            score1 = 60;
        else
            score1 = 30;

        if(tg.sab2 == "S")
            score2 = 90;
        else if(tg.sab2 == "A")
            score2 = 60;
        else
            score2 = 30;   

        if(tg.sab3 == "S")
            score3 = 90;
        else if(tg.sab3 == "A")
            score3 = 60;
        else
            score3 = 30;
    }

    void CalTotal()
    {
        CalScore();
        totalScore = score1 + score2 + score3;

        // 최종 점수에 따라 재화를 얻음
        if(totalScore >= 240) // S S A
        {
            // 코인
            SingleTon.Instance.coin += 300;
        }
        else if(totalScore >= 150) // A A B
        {
            // 코인
            SingleTon.Instance.coin += 200;
        }
        else
        {
            // 코인
            SingleTon.Instance.coin += 100;
        }
    }

    public void GameOverClear()
    {
        CalTotal();
        if(totalScore >= 150)
        {
            SceneManager.LoadScene("GameClearScene");
            SingleTon.Instance.level++;
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
