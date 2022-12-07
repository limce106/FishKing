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
    private ToppingGC tgc;
    private TotalScore ts;
    // �δ��� ��� Ȯ��(����)
    private float chance;
    // ��� �ؽ�Ʈ Ȱ��ȭ ����
    public bool isStageGrade = false;
    public AudioClip audioGrade;
    AudioSource audioSource;

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

        if(SceneManager.GetActiveScene().name == "ToppingScene")
        {
            tgc = GameObject.Find("ToppingGC").GetComponent<ToppingGC>();
        }

        ts = GetComponent<TotalScore>();

        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void StageGrade()
    {
        // ���� ��� ���
        if(SceneManager.GetActiveScene().name == "Dough")
        {
            if (dough.spaceCount >= 50)
            {
                SingleTon.Instance.sab1 = "S";
                //ts.score1 = 90;
                Debug.Log("S"); ;
            }
            else if (dough.spaceCount >= 35)
            {
                SingleTon.Instance.sab1 = "A";
                //ts.score1 = 60;
                Debug.Log("A");
            }
            else
            {
                SingleTon.Instance.sab1 = "B";
                //ts.score1 = 30;
                Debug.Log("B");
            }

            gradeText.text = SingleTon.Instance.sab1;
        }

        // ���� ��� ���
        else if(SceneManager.GetActiveScene().name == "ToppingScene")
        {
            if (tgc.coinCount >= 30)
                SingleTon.Instance.sab2 = "S";
            else if (tgc.coinCount >= 20)
                SingleTon.Instance.sab2 = "A";
            else
                SingleTon.Instance.sab2 = "B";

            gradeText.text = SingleTon.Instance.sab2;
        }

        // ���� ��� ���
        else if(SceneManager.GetActiveScene().name == "Bake1" || SceneManager.GetActiveScene().name == "Bake2")
        {
            // �δ��� ���� Ȯ��
            chance = hammer.hitCount / moleSpawner.spawnCount * 100;

            if(chance >= 80)
            {
                SingleTon.Instance.sab3 = "S";
            }
            else if(chance >= 60)
            {
                SingleTon.Instance.sab3 = "A";
            }
            else
            {
                SingleTon.Instance.sab3 = "B";
            }

            gradeText.text = SingleTon.Instance.sab3;
        }

        gradeText.gameObject.SetActive(true);
    }

    public void PrintGrade()
    {
        Invoke("StageGrade", 1f);
        isStageGrade = true;
        audioSource.PlayOneShot(audioGrade);
    }
}
