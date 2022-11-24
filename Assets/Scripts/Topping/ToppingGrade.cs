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
    public Text timer;
    public float time = 0; // ?? ???? ??? ??? ???? ?? ??

    void Start()
    {
        grade = GameObject.Find("Grade").GetComponent<Text>();
    }

    public void CalGrade()
    {
        // ??? ?? ??
        chance = hammer.hitCount / moleSpawner.spawnCount * 100;

        if(chance >= 90)
            grade.text = "S";
        else if(chance >= 70)
            grade.text = "A";
        else
            grade.text = "B";

        grade.gameObject.SetActive(true);
    }

    public void PrintGrade()
    {
        Invoke("CalGrade", 1.3f);
    }
}
