using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 충돌을 처리하는 스크립트
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private ToppingGC gameController;

    public AudioClip audioCoin;
    public AudioClip audioObstacle;
    AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Obstacle"))
        {
            // Coin 수 감소
            gameController.DecreaseCoinCount();
            audioSource.PlayOneShot(audioObstacle);
        }

        if (other.tag.Equals("Coin"))
        {
            gameController.IncreaseCoinCount();
            audioSource.PlayOneShot(audioCoin);
        }

        if (other.tag.Equals("Wall"))
        {
            // 게임 오버
            gameController.GameOver();
            audioSource.PlayOneShot(audioObstacle);
        }


    }
}
