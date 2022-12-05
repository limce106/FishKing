using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TotalScore : MonoBehaviour
{
    private TotalGrade tg;
    public int score1;
    public int score2;
    public int score3;

    void Start()
    {
        tg = GetComponent<TotalGrade>();

        if(SceneManager.GetActiveScene().name == "GameClearScene")
        {
            SingleTon.Instance.level += 1;
            GetCoin();
        }

        if(SceneManager.GetActiveScene().name == "GameOverScene")
        {
            GetCoin();
        }
    }

    void Update()
    {
        
    }

    void CalScore()
    {
        if(SingleTon.Instance.sab1 == "S")
            score1 = 90;
        else if(SingleTon.Instance.sab1 == "A")
            score1 = 60;
        else
            score1 = 30;

        if(SingleTon.Instance.sab2 == "S")
            score2 = 90;
        else if(SingleTon.Instance.sab2 == "A")
            score2 = 60;
        else
            score2 = 30;   

        if(SingleTon.Instance.sab3 == "S")
            score3 = 90;
        else if(SingleTon.Instance.sab3 == "A")
            score3 = 60;
        else
            score3 = 30;
    }

    public void GameOverClear()
    {
        CalScore();
        SingleTon.Instance.totalScore = score1 + score2 + score3;
        Debug.Log(SingleTon.Instance.totalScore);

        if(SingleTon.Instance.totalScore > 120)
        {
            SceneManager.LoadScene("GameClearScene");
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void GetCoin()
    {
        Debug.Log(SingleTon.Instance.totalScore);
        
        // 최종 점수에 따라 재화를 얻음
        if(SingleTon.Instance.totalScore >= 240) // S S A
        {
            // 코인
            SingleTon.Instance.coin += 300;
        }
        else if(SingleTon.Instance.totalScore >= 150) // A A B
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
}
