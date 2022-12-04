using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBowl : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true)
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        else 
        {
            transform.localScale = new Vector3(0.38f, 0.38f, 0.38f);
        }
        
    }

}
