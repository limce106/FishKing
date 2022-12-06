using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayMng : MonoBehaviour
{
    AudioSource bgm = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    public GameObject pauseButton;

    // ���/���߱� ��ư �Լ�
    public void PauseButton()
    {
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
    }
}
