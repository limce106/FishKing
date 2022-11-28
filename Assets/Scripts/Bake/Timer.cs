using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float time;     // Ÿ�̸� �ð�
    public TotalGrade totalGrade;
    private TotalScore totalScore;

    private void Awake () 
    {
        totalGrade = GameObject.Find("DataMng").GetComponent<TotalGrade>();
        if(SceneManager.GetActiveScene().name == "Topping")
        {
            totalScore = GameObject.Find("DataMng").GetComponent<TotalScore>();
        }
        // Ÿ�̸� �ð� ����
        time = 3f;
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

        // Ceil: �ø� �Լ�
        timer.text = Mathf.Ceil(time).ToString();

        Invoke("NextScene", 1f);
    }

    public void NextScene()
    {
        if(timer.text == "0")
        {
            if(SceneManager.GetActiveScene().name == "Dough")
            {
                SceneManager.LoadScene("Bake");
            }
            else if(SceneManager.GetActiveScene().name == "Bake")
            {
                SceneManager.LoadScene("Topping");
            }
            else if(SceneManager.GetActiveScene().name == "Topping")
            {
                totalScore.GameOverClear();
            }
        }
    }
}
