using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TotalScore : MonoBehaviour
{
    private ToppingGrade tg;
    private int score1;
    private int score2;
    private int score3;
    private int totalScore;

    void Start()
    {
        tg = GetComponent<ToppingGrade>();
    }

    void Update()
    {
        CalScore();
        CalTotal();
        GameOverClear();
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
        totalScore = score1 + score2 + score3;
        if(totalScore >= 240) // S S A
        {
            // 코인
        }
        else if(totalScore >= 150) // A A B
        {
            // 코인
        }
        else
        {
            // 코인
        }
    }

    void GameOverClear()
    {
        if(totalScore >= 150)
        {
            SceneManager.LoadScene("GameClear");
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
