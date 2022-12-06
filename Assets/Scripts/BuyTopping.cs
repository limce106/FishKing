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
        SingleTon.Instance.coin -= 50;
        audioSource.PlayOneShot(audioBuy);
    }
    public void MintChoco()
    {
        SingleTon.Instance.coin -= 100;
        audioSource.PlayOneShot(audioBuy);
    }
    public void Fish()
    {
        SingleTon.Instance.coin -= 150;
        audioSource.PlayOneShot(audioBuy);
    }
    public void Rainbow()
    {
        SingleTon.Instance.coin -= 200;
        audioSource.PlayOneShot(audioBuy);
    }
    public void Ramen()
    {
        SingleTon.Instance.coin -= 250;
        audioSource.PlayOneShot(audioBuy);
    }
    public void Pizza()
    {
        SingleTon.Instance.coin -= 300;
        audioSource.PlayOneShot(audioBuy);
    }
}
