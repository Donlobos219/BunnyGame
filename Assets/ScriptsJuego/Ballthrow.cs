using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ballthrow : MonoBehaviour
{
    public static Vector3 playerPos;

    private Rigidbody rb;

    float xroat, yroat = 0f;
    public Rigidbody ball;
    public float rotatespeed = 5f;
    public LineRenderer Line;
    public float shootpower = 30f;
    public float shootpower2 = 15f;

    float min = -35;
    float max = 35;

    bool onGround = true;
    bool canDoubleJump = false;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrackPlayer());

        rb = GetComponent<Rigidbody>();
    }

    void Rotate()
    {

        RaycastHit hit;
        Vector3 physicsCentre = this.transform.position + this.GetComponent<CapsuleCollider>().center;
        if (Physics.Raycast(physicsCentre, Vector3.down, out hit, 1.5f))
        {
            onGround = true;
            
        }
        else
        {
            onGround = false;
        }
    }

    /*
 
    // Update is called once per frame
    void Update()
    {
        Rotate();

        transform.position = ball.position;
        if (Input.GetMouseButton(0)&& onGround)
            {             
                    xroat += Input.GetAxis("Mouse X") * rotatespeed;
                    yroat += Input.GetAxis("Mouse Y") * rotatespeed;
                    yroat = Mathf.Clamp(yroat, min, max);
                    transform.localRotation = Quaternion.Euler(-yroat, xroat, 0f);
                    Line.gameObject.SetActive(true);
                    Line.SetPosition(0, transform.position);
                    Line.SetPosition(1, transform.position + transform.forward * 4f);
                    
                    if (yroat < -35f)
                    {
                        yroat = -35f;
                    }                    
             }


        if (Input.GetMouseButton(0))
        {
            xroat += Input.GetAxis("Mouse X") * rotatespeed;
            yroat += Input.GetAxis("Mouse Y") * rotatespeed;
            yroat = Mathf.Clamp(yroat, min, max);
            transform.localRotation = Quaternion.Euler(-yroat, xroat, 0f);
        }
            if (Input.GetMouseButtonUp(0) && onGround)
        {         
                ball.velocity = transform.forward * shootpower;
                Line.gameObject.SetActive(false);
                canDoubleJump = false;
        }
           
    }

    */
    IEnumerator TrackPlayer()
    {
        while (true)
        {
            playerPos = gameObject.transform.position;
            yield return null;
        }
    }

}
