using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 충돌을 처리하는 스크립트
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
