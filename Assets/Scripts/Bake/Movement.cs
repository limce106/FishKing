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
            moveSpeed = 2f;
        }

        else if(SingleTon.Instance.level == 2)
        {
            
        }

        else if(SingleTon.Instance.level == 3)
        {

        }

        else if(SingleTon.Instance.level == 4)
        {

        }

        else if(SingleTon.Instance.level == 5)
        {

        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
