using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo3 : MonoBehaviour
{
    public Timer3 tiempo1;
    public float tiempoAgregado =10f;
    public GameObject texto;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag==("Player"))
        {
            
            tiempo1.currentTime += tiempoAgregado;
            Instantiate(texto, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
