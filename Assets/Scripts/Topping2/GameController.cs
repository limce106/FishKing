using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTitle;
    [SerializeField]
    private TextMeshProUGUI textTapToPlay;

    [SerializeField]
    private TextMeshProUGUI textCoinCount;
    private int coinCount = 0;


    public bool IsGameStart { private set; get; }

    private void Awake()
    {
        IsGameStart = false;

        textTitle.enabled = true;
        textTapToPlay.enabled = true;
        textCoinCount.enabled = false;
    }

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        // 마우스 왼쪽 버튼을 누르기 전까지 시작하지 않고 대기
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                IsGameStart = true;

                textTitle.enabled = false;
                textTapToPlay.enabled = false;
                textCoinCount.enabled = true;

                break;
            }

            yield return null;
        }
    }

    // 코인 수 감소
    public void IncreaseCoinCount()
    {
        coinCount++;
        textCoinCount.text = coinCount.ToString();
    }

    // 코인 수 증가
    public void DecreaseCoinCount()
    {
        coinCount -= 10;
        textCoinCount.text = coinCount.ToString();
    }

    public void GameOver()
    {
        // 현재 씬 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
