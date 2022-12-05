using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0;
    private Vector3 moveDirection = Vector3.zero;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(SingleTon.Instance.level == 1)
        {
            moveSpeed = 1.5f;
        }

        else if(SingleTon.Instance.level == 2)
        {
            moveSpeed = 1.7f;
        }

        else if(SingleTon.Instance.level == 3)
        {
            moveSpeed = 2f;
        }

        else if(SingleTon.Instance.level == 4)
        {
            moveSpeed = 2.2f;
        }

        else if(SingleTon.Instance.level == 5)
        {
            moveSpeed = 2.4f;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
