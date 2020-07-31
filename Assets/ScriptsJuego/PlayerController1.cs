using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Taller;

public class PlayerController1 : MonoBehaviour
{
    public float rotationSpeed = 1;
    public bool canLaunch = false;
  
    public Rigidbody ball;
    public float rotatespeed = 5f;
    public LineRenderer Line;
    public float shootpower = 30f;
    public float shootpower2 = 15f;
    // Start is called before the first frame update
    void Start()
    {
        canLaunch = true;
        EventTouch.OnHold = OnHold;
        EventTouch.OnSwipeFinished = OnSwipeFinished;
    }

    void OnHold(TouchResult touchResult)
    {
        if (canLaunch == false) return;

        float side=touchResult.direction4WayVector.x*-1;

        transform.RotateAround(transform.position,Vector3.up, rotationSpeed*side);

        
    }
    void OnSwipeFinished(TouchResult touchResult)
    {
        if (ball == null) return;
        if (canLaunch == false) return;
        ball.velocity = ball.transform.forward * shootpower;
        canLaunch = false;

    }
    void Update()
    {
        if (ball)
            transform.position = ball.position;
    }
   
}
