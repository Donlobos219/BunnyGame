using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce2 : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rigidPlayer;

    
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            rigidPlayer.velocity = new Vector3(0, 90, 45) * speed;
            
        }
    }
}


