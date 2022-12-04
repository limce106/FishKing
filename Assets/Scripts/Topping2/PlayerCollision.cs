using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �浹�� ó���ϴ� ��ũ��Ʈ
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private ToppingGC gameController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Obstacle"))
        {
            // Coin �� ����
            gameController.DecreaseCoinCount();
        }

        if (other.tag.Equals("Coin"))
        {
            gameController.IncreaseCoinCount();
        }

        if (other.tag.Equals("Wall"))
        {
            // ���� ����
            gameController.GameOver();
        }


    }
}
