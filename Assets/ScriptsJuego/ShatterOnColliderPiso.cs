using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnColliderPiso : MonoBehaviour
{
    public GameObject replacement;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Piso")
        {
            GameObject.Instantiate(replacement, transform.position, transform.rotation);

            

            Destroy(gameObject);
        }
    }

}
