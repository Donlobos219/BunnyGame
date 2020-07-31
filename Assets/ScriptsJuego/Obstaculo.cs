using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocity;
    public bool destruible;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MueveObstaculo()
    {
        GetComponent<Rigidbody>().position += Vector3.right * velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DestroyTrigger")==true && destruible == true)
        {
            Destroy(gameObject);
        }





    
    }
    // Update is called once per frame
    void Update()
    {
        MueveObstaculo();
    }
}
