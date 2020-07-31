using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3Trigger : MonoBehaviour
{
    public float delay = 2;
    
    public string NewLevel3 = "Nivel3Final";

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
            StartCoroutine(LoadLevel3AfterDelay(delay));
        }

    }

    IEnumerator LoadLevel3AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel3);
    }
}
