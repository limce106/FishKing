using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTextScript : MonoBehaviour
{
    public Text ScriptTxt;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "~�� �ؾ �ּ���!";
    }

    // Update is called once per frame
    void Update()
    {
        if(level == 1)
        {
            ScriptTxt.text = "�� �ؾ �ּ���!";
        }
        else if (level == 2)
        {
            ScriptTxt.text = "��ũ�� �ؾ �ּ���!";
        }
        else if (level == 3)
        {
            ScriptTxt.text = "�ͻ��  �ؾ �ּ���!";
        }
        else if (level == 4)
        {
            ScriptTxt.text = "���󵵽� �ؾ �ּ���!";
        }


    }
}
