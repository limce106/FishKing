using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float time;     // Ÿ�̸� �ð�
    public ToppingGrade toppingGrade;

    private void Awake () 
    {
        time = 5f;
    }

    void Update()
    {
        if(toppingGrade.grade.enabled == true)
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
