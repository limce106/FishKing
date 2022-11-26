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
        ScriptTxt.text = "~咐 贺绢户 林技夸!";
    }

    // Update is called once per frame
    void Update()
    {
        if(level == 1)
        {
            ScriptTxt.text = "葡 贺绢户 林技夸!";
        }
        else if (level == 2)
        {
            ScriptTxt.text = "酱农覆 贺绢户 林技夸!";
        }
        else if (level == 3)
        {
            ScriptTxt.text = "客荤厚  贺绢户 林技夸!";
        }
        else if (level == 4)
        {
            ScriptTxt.text = "凹扼档胶 贺绢户 林技夸!";
        }


    }
}
