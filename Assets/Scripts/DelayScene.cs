using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScene : MonoBehaviour
{
    private float fDestroyTime = 2f;
    private float fTickTime;
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fTickTime += Time.deltaTime;

       if ( fTickTime >= fDestroyTime)
       {
            Time.timeScale = 1;
       }
    }
}
