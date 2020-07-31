using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ShatterOnCollider : MonoBehaviour
{
    public GameObject replacement;
    public GameObject llave;

    public float gravityScale = 8.0f;

    public static float globalGravity = -9.81f;

    private Rigidbody m_rb;


    void OnEnable()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Roca")
        {
            GameObject.Instantiate(replacement, transform.position, transform.rotation);

            GameObject.Instantiate(llave, transform.position, transform.rotation);

            Destroy(gameObject);

            
        }
    }

}
