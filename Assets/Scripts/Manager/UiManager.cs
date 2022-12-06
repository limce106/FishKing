using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text levelText;
    public Text coinText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level. " + SingleTon.Instance.level;

        //if (SingleTon.Instance.level == 1)
        //{
        //    levelText.text = "Level.1";
        //}
        //else if (SingleTon.Instance.level == 2)
        //{
        //    levelText.text = "Level.2";
        //}
        //else if (SingleTon.Instance.level == 3)
        //{
        //    levelText.text = "Level.3";
        //}
        //else if (SingleTon.Instance.level == 4)
        //{
        //    levelText.text = "Level.4";
        //}
        //else if (SingleTon.Instance.level == 5)
        //{
        //    levelText.text = "Level.5";
        //}

        // if(SingleTon.Instance.coin != 0)
        // {
        //     int coin = SingleTon.Instance.coin;
        //     coinText.text = coin + "$";
        // }
        coinText.text = SingleTon.Instance.coin + "$";   
    }
}
