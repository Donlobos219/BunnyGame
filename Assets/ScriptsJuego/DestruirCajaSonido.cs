using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirCajaSonido : MonoBehaviour
{
    public AudioSource source;

    public AudioClip[] destruir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Caja")
        {
            source.clip = destruir[Random.Range(0, destruir.Length)];
            source.Play();
        }
    }
}
