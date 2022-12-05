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
        // ���콺 ���� ��ư�� ������ ������ �������� �ʰ� ���
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

    // ���� �� ����
    public void IncreaseCoinCount()
    {
        coinCount ++;
        textCoinCount.text = (coinCount * 100).ToString();
    }

    // ���� �� ����
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
        // ���� �� �ٽ� �ε�
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // �÷��̾��� ������ ���߱�
        IsGameStart = false;

        tg.PrintGrade();
    }
}
