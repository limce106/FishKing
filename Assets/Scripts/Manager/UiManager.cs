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
        coinText.text = SingleTon.Instance.coin + "$";   
    }
}
