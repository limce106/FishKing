using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToppingGrade : MonoBehaviour
{
    public MoleSpawner moleSpawner;
    public Hammer hammer;
    public Text grade;
    private float chance;

    void Start()
    {
        grade = GameObject.Find("Grade").GetComponent<Text>();
    }

    public void CalGrade()
    {
        // 두더지를 맞힌 확률
        chance = hammer.hitCount / moleSpawner.spawnCount * 100;

        if(chance >= 90)
            grade.text = "S급";
        else if(chance >= 70)
            grade.text = "A급";
        else
            grade.text = "B급";

        grade.gameObject.SetActive(true);
    }

    public void AfterSec()
    {
        Invoke("CalGrade", 1.3f);
    }
}
