using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBowl : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true)
        {
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else 
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }

}
