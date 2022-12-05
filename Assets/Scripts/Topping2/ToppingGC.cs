using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToppingGC : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTitle;
    [SerializeField]
    private TextMeshProUGUI textTapToPlay;

    [SerializeField]
    private TextMeshProUGUI textCoinCount;
    public int coinCount = 0;
    public TotalGrade tg;

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

    // 코인 수 증가
    public void IncreaseCoinCount()
    {
        coinCount ++;
        textCoinCount.text = (coinCount * 100).ToString();
    }

    // 코인 수 감소
    public void DecreaseCoinCount()
    {
        coinCount -= 10;
        if(coinCount < 0)
        {
            coinCount = 0;
        }
        textCoinCount.text = (coinCount * 100).ToString();
    }

    public void GameOver()
    {
        // 현재 씬 다시 로드
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // 플레이어의 움직임 멈추기
        IsGameStart = false;

        tg.PrintGrade();
    }
}
