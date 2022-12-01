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
    public string sab1;
    public string sab2;
    public string sab3;

    void Start()
    {
        //grade = GameObject.Find("Grade").GetComponent<Text>();
    }

    public void Topping_Grade()
    {
        // 두더지 잡을 확률
        chance = hammer.hitCount / moleSpawner.spawnCount * 100;

        if(chance >= 90)
            sab3 = "S";
        else if(chance >= 70)
            sab3 = "A";
        else
            sab3 = "B";

        grade.text = sab3;
        grade.gameObject.SetActive(true);
    }


    public void PrintGrade()
    {
        Invoke("Topping_Grade", 1.3f);
    }
}
