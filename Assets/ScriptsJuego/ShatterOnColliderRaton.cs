using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnColliderRaton : MonoBehaviour
{
    public GameObject replacement;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Raton")
        {
            GameObject.Instantiate(replacement, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
