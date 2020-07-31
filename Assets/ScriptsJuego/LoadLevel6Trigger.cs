using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel6Trigger : MonoBehaviour
{
    public float delay =2;

    public AudioSource fallar;

    public string NewLevel6 = "Nivel6Final";
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
            StartCoroutine(LoadLevel6AfterDelay(delay));
        }

    }

    IEnumerator LoadLevel6AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel6);
    }
}
