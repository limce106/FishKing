using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ����� ��ũ��Ʈ
public class Audio : MonoBehaviour
{
    GameObject audio;
    AudioSource bgm;
    void Start()
    {
        audio = GameObject.Find("AudioManager");
        bgm = audio.GetComponent<AudioSource>();
        // ����� ���
        bgm.Play();
    }

    void Update()
    {

    }
}
