﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPlatform : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0f;
    public float journeyLength = 1.0f;
    private float startTime;

    public bool loop = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (loop)
        {
            float distCovered = (Time.time - startTime) * speed;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered / journeyLength);
        }
        if (loop)
        {
            float distCovered = Mathf.PingPong(Time.time - startTime, journeyLength / speed);
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered / journeyLength);
        }
    }
}
