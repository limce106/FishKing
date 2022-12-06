using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �浹�� ó���ϴ� ��ũ��Ʈ
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
            // Coin �� ����
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
            // ���� ����
            gameController.GameOver();
            audioSource.PlayOneShot(audioObstacle);
        }


    }
}
