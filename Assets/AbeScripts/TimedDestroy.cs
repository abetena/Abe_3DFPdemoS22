using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{

    public float destroyDelay = 1.0f;


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyDelay);
    }

}
