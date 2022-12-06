using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayMng : MonoBehaviour
{
    AudioSource bgm;
    GameObject pauseButton;
    public AudioClip audioButton;
    AudioSource audioSource;

    void Start()
    {
        bgm = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        pauseButton = GameObject.Find("pauseButton");
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // ���/���߱� ��ư �Լ�
    public void PauseButton()
    {
        Debug.Log(pauseButton.GetComponent<Image>().sprite.name);
        // ��������Ʈ�� �Ͻ������̰� �ð��� �帣�� ���� �� ��ư�� ������
        if (pauseButton.GetComponent<Image>().sprite.name == "Stop" && Time.timeScale == 1)
        {
            // ����
            Time.timeScale = 0;
            // ��������Ʈ�� ������� ����
            pauseButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Start") as Sprite;
            // bgm �Ͻ�����
            bgm.Pause();
        }
        // ��������Ʈ�� ����̰� �ð��� ������ �� ��ư�� ������
        else if (pauseButton.GetComponent<Image>().sprite.name == "Start" && Time.timeScale == 0)
        {
            // �ð� �帧
            Time.timeScale = 1;
            // ��������Ʈ�� �Ͻ������� ����
            pauseButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Stop") as Sprite;
            // bgm ���
            bgm.Play();
        }

        audioSource.PlayOneShot(audioButton);
    }
}
