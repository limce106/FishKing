using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 충돌을 처리하는 스크립트
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private ToppingGC gameController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Obstacle"))
        {
            // Coin 수 감소
            gameController.DecreaseCoinCount();
        }

        if (other.tag.Equals("Coin"))
        {
            gameController.IncreaseCoinCount();
        }

        if (other.tag.Equals("Wall"))
        {
            // 게임 오버
            gameController.GameOver();
        }


    }
}
