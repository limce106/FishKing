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
        SceneManager.LoadScene("Startscene");
    }
    public void GameOff()
    {
        Application.Quit();
    }
}
