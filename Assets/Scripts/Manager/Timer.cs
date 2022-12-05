using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float time;     // 타이머 시간
    public TotalGrade totalGrade;
    private TotalScore totalScore;

    private void Awake () 
    {
        totalGrade = GameObject.Find("DataMng").GetComponent<TotalGrade>();
        if(SceneManager.GetActiveScene().name == "ToppingScene")
        {
            totalScore = GameObject.Find("DataMng").GetComponent<TotalScore>();
        }
        // 타이머 시간 설정
        time = 5f;
    }

    void Update()
    {
        if(totalGrade.isStageGrade == true)
        {
            Invoke("StartTimer", 2f);
        }
    }

    public void StartTimer()
    {
        timer.gameObject.SetActive(true);
        if (time > 0)
            time -= Time.deltaTime;

        // Ceil: 올림 함수
        timer.text = Mathf.Ceil(time).ToString();

        Invoke("NextScene", 1f);
    }

    public void NextScene()
    {
        if(timer.text == "0")
        {
            if(SceneManager.GetActiveScene().name == "Dough")
            {
                if(SingleTon.Instance.level == 5)
                {
                    SceneManager.LoadScene("Bake2");
                }
                else
                {
                    SceneManager.LoadScene("Bake1");
                }
            }
            else if(SceneManager.GetActiveScene().name == "Bake1" || SceneManager.GetActiveScene().name == "Bake2")
            {
                SceneManager.LoadScene("ToppingScene");
            }
            else if(SceneManager.GetActiveScene().name == "ToppingScene")
            {
                totalScore.GameOverClear();
            }
        }
    }
}
