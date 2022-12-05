using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrderTextScript : MonoBehaviour
{
    public Text orderText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SingleTon.Instance.level == 1)
        {
            orderText.text = "�� �ؾ �ּ���!";
        }
        else if (SingleTon.Instance.level == 2)
        {
            orderText.text = "��ũ�� �ؾ �ּ���!";
        }
        else if (SingleTon.Instance.level == 3)
        {
            orderText.text = "���� �ؾ �ּ���!";
        }
        else if (SingleTon.Instance.level == 4)
        {
            orderText.text = "�ͻ�� �ؾ �ּ���!";
        }
        else if (SingleTon.Instance.level == 5)
        {
            orderText.text = "���󵵽� �ؾ �ּ���!";
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Dough");
        }
    }
}
