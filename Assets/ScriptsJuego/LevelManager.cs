using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Nivel1Final()
    {
        SceneManager.LoadScene("Nivel1Final");
    }

    public void Nivel2Final()
    {
        SceneManager.LoadScene("Nivel2Final");
    }

    public void Nivel3Final()
    {
        SceneManager.LoadScene("Nivel3Final");
    }

    public void Nivel4Final()
    {
        SceneManager.LoadScene("Nivel4Final");
    }

    public void Nivel6Final()
    {
        SceneManager.LoadScene("Nivel6Final");
    }

    public void Nivel7Final()
    {
        SceneManager.LoadScene("Nivel7Final");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
