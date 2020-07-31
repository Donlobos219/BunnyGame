using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager2 : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    
    // Start is called before the first frame update

    void Update()
    {
        
    }
    public void DoSlowmotion()
    {
        

    }

    void Start()
    {
        Time.timeScale += (1f) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
