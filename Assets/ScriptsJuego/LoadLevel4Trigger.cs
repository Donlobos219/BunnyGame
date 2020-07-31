using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel4Trigger : MonoBehaviour
{
    public float delay = 2;

    
    public string NewLevel4 = "Nivel4Final";


    public AudioSource fallar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            fallar.Play();
            StartCoroutine(LoadLevel4AfterDelay(delay));
        }

    }

    IEnumerator LoadLevel4AfterDelay(float delay)
    {


        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel4);
    }
}
