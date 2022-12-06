using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GotoClearBtn()
    {
        SceneManager.LoadScene("GameClearScene");
    }
    public void GotoOverBtn()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void GotoStartBtn()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void GameOff()
    {
        Application.Quit();
    }
    public void GotoDough()
    {
        SceneManager.LoadScene("Dough");
    }
    public void GotoOrder()
    {
        SceneManager.LoadScene("OrderScene");
    }
    public void GotoStore()
    {
        SceneManager.LoadScene("Store");
    }
}
