using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� �浹�� ó���ϴ� ��ũ��Ʈ
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
       // if(other.tag.Equals("Obstacle"))
       // {
       //     gameController.GameOver();
        //}
         if (other.tag.Equals("Coin"))
        {
            gameController.IncreaseCoinCount();
        }
    }
}
