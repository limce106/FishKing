using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float time;     // 타이머 시간
    public ToppingGrade toppingGrade;

    private void Awake () 
    {
        toppingGrade = GameObject.Find("GameMng").GetComponent<ToppingGrade>();
        time = 5f;
    }

    void Update()
    {
        if(toppingGrade.grade.enabled == true)
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
        Invoke("StartTimer", 2f);
        
        timer.gameObject.SetActive(true);
        if (time > 0)
            time -= Time.deltaTime;

        // Ceil: 올림 함수
        timer.text = Mathf.Ceil(time).ToString();

        Invoke("NextScene", 1.3f);
    }

    public void NextScene()
    {
        if(timer.text == "0")
        {
            SceneManager.LoadScene("Bake");
        }
    }
}
