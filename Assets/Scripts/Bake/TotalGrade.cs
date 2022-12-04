using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TotalGrade : MonoBehaviour
{
    public MoleSpawner moleSpawner;
    public Hammer hammer;
    public Text gradeText;
    private Dough dough;
    private float chance;
    public string sab1;
    public string sab2;
    public string sab3;
    public bool isStageGrade = false;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Dough")
        {
            dough = GameObject.Find("Dough").GetComponent<Dough>();
        }

        if(SceneManager.GetActiveScene().name == "Bake1" || SceneManager.GetActiveScene().name == "Bake2")
        {
            moleSpawner = GameObject.Find("MoleSpawner").GetComponent<MoleSpawner>();
            hammer = GameObject.Find("Hammer").GetComponent<Hammer>();
        }
    }

    public void StageGrade()
    {
        // 반죽 등급 계산
        if(SceneManager.GetActiveScene().name == "Dough")
        {
            if (dough.spaceCount >= 30)
            {
                sab1 = "S";
                Debug.Log("S"); ;
            }
            else if (dough.spaceCount >= 20)
            {
                sab1 = "A";
                Debug.Log("A");
            }
            else
            {
                sab1 = "B";
                Debug.Log("B");
            }

            gradeText.text = sab1;
        }

        // 굽기 등급 계산
        else if(SceneManager.GetActiveScene().name == "Bake1" || SceneManager.GetActiveScene().name == "Bake2")
        {
            // 두더지 잡을 확률
            chance = hammer.hitCount / moleSpawner.spawnCount * 100;

            if(chance >= 90)
                sab2 = "S";
            else if(chance >= 70)
                sab2 = "A";
            else
                sab2 = "B";

            gradeText.text = sab2;
        }

        // 토핑 등급 계산
        else if(SceneManager.GetActiveScene().name == "Topping")
        {

            gradeText.text = sab3;
        }

        gradeText.gameObject.SetActive(true);
    }

    public void PrintGrade()
    {
        Invoke("StageGrade", 1f);
        isStageGrade = true;
    }
}
