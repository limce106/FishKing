using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayMng : MonoBehaviour
{
    AudioSource bgm;
    GameObject pauseButton;

    void Start()
    {
        bgm = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "Dough")
        pauseButton = GameObject.Find("pauseButton");
    }

    // 재생/멈추기 버튼 함수
    public void PauseButton()
    {
        Debug.Log(pauseButton.GetComponent<Image>().sprite.name);
        // 스프라이트가 일시정지이고 시간이 흐르고 있을 때 버튼을 누르면
        if (pauseButton.GetComponent<Image>().sprite.name == "Stop" && Time.timeScale == 1)
        {
            // 멈춤
            Time.timeScale = 0;
            // 스프라이트는 재생으로 변경
            pauseButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Start") as Sprite;
            // bgm 일시정지
            bgm.Pause();
        }
        // 스프라이트가 재생이고 시간이 멈췄을 때 버튼을 누르면
        else if (pauseButton.GetComponent<Image>().sprite.name == "Start" && Time.timeScale == 0)
        {
            // 시간 흐름
            Time.timeScale = 1;
            // 스프라이트는 일시정지로 변경
            pauseButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Stop") as Sprite;
            // bgm 재생
            bgm.Play();
        }
    }
}
