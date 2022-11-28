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
            orderText.text = "葡 贺绢户 林技夸!";
        }
        else if (SingleTon.Instance.level == 2)
        {
            orderText.text = "酱农覆 贺绢户 林技夸!";
        }
        else if (SingleTon.Instance.level == 3)
        {
            orderText.text = "绊备付 贺绢户 林技夸!";
        }
        else if (SingleTon.Instance.level == 4)
        {
            orderText.text = "客荤厚 贺绢户 林技夸!";
        }
        else if (SingleTon.Instance.level == 5)
        {
            orderText.text = "凹扼档胶 贺绢户 林技夸!";
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Dough");
        }
    }
}
