using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public AudioClip audioButton;
    AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void GotoClearBtn()
    {
        SceneManager.LoadScene("GameClearScene");
        audioSource.PlayOneShot(audioButton);
    }
    public void GotoOverBtn()
    {
        SceneManager.LoadScene("GameOverScene");
        audioSource.PlayOneShot(audioButton);
    }
    public void GotoStartBtn()
    {
        SceneManager.LoadScene("StartScene");
        audioSource.PlayOneShot(audioButton);
    }
    public void GameOff()
    {
        Application.Quit();
        audioSource.PlayOneShot(audioButton);
    }
    public void GotoDough()
    {
        SceneManager.LoadScene("Dough");
        audioSource.PlayOneShot(audioButton);
    }
    public void GotoOrder()
    {
        SceneManager.LoadScene("OrderScene");
        audioSource.PlayOneShot(audioButton);
    }
    public void GotoStore()
    {
        SceneManager.LoadScene("Store");
        audioSource.PlayOneShot(audioButton);
    }
}
