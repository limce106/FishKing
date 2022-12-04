using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTopping : MonoBehaviour
{
    public void Grass()
    {
        SingleTon.Instance.coin -= 50;
    }
    public void MintChoco()
    {
        SingleTon.Instance.coin -= 100;
    }
    public void Fish()
    {
        SingleTon.Instance.coin -= 150;
    }
    public void Rainbow()
    {
        SingleTon.Instance.coin -= 200;
    }
    public void Ramen()
    {
        SingleTon.Instance.coin -= 250;
    }
    public void Pizza()
    {
        SingleTon.Instance.coin -= 300;
    }
}
