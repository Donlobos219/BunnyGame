using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerSlowMotion : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
    public void DoSlowmotion ()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .10f;

    }

    public void RealTime()
    {
        Time.timeScale = 1.0f;
    }
}
