using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBowl : MonoBehaviour
{
    public AudioClip audioDough;
    AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            audioSource.PlayOneShot(audioDough);
        }
        else 
        {
            transform.localScale = new Vector3(0.38f, 0.38f, 0.38f);
        }
        
    }

}
