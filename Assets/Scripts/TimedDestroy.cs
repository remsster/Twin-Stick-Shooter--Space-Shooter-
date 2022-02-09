using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    // Script for destroing the particle system
    public float DestroyTime = 2f;

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    
}
