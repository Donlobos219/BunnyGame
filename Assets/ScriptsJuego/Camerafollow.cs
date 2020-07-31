using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform Target;

    public float speed = 15;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, speed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
