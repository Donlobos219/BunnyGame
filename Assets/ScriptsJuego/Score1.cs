using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score1 : MonoBehaviour
{
    public static int scoreValue = 0;
    Text puntaje;

    // Start is called before the first frame update
    void Start()
    {
        puntaje = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        puntaje.text = "PUNTAJE: " + scoreValue; 

        if (scoreValue > 600)
        {
            SceneManager.LoadScene(1);
        }
    }
}
