using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTopping : MonoBehaviour
{
    public AudioClip audioBuy;
    AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void Grass()
    {
        if(SingleTon.Instance.coin >= 50)
        {
            SingleTon.Instance.coin -= 50;
            audioSource.PlayOneShot(audioBuy);
        }
       
    }
    public void MintChoco()
    {
        if (SingleTon.Instance.coin >= 100)
        {
            SingleTon.Instance.coin -= 100;
            audioSource.PlayOneShot(audioBuy);
        }
    }
    public void Fish()
    {
        if (SingleTon.Instance.coin >= 150)
        {
            SingleTon.Instance.coin -= 150;
            audioSource.PlayOneShot(audioBuy);
        }
    }
    public void Rainbow()
    {
        if (SingleTon.Instance.coin >= 200)
        {
            SingleTon.Instance.coin -= 200;
            audioSource.PlayOneShot(audioBuy);
        }
    }
    public void Ramen()
    {
        if (SingleTon.Instance.coin >= 250)
        {
            SingleTon.Instance.coin -= 250;
            audioSource.PlayOneShot(audioBuy);
        }
    }
    public void Pizza()
    {
        if (SingleTon.Instance.coin >= 300)
        {
            SingleTon.Instance.coin -= 300;
            audioSource.PlayOneShot(audioBuy);
        }
    }
}
