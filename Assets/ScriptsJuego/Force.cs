using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public Rigidbody rb;
    public float BallPower;

    public Vector2 minimumpower;
    public Vector2 maximumpower;
    public LineRenderer line;
    Camera camera;
    Vector2 ballforce;
    Vector3 startpoint;
    Vector3 endpoint;

    
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetMouseButtonDown(0))
        {
            startpoint = camera.ScreenToWorldPoint(Input.mousePosition);
            startpoint.z = 15;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentpoint = camera.ScreenToWorldPoint(Input.mousePosition);
            currentpoint.z = 15;
            Drawlint(startpoint, currentpoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endpoint = camera.ScreenToWorldPoint(Input.mousePosition);
            endpoint.z = 15;

            ballforce = new Vector2(Mathf.Clamp(startpoint.x - endpoint.x, minimumpower.x, maximumpower.x), Mathf.Clamp(startpoint.y - endpoint.y, minimumpower.y, maximumpower.y));
            rb.AddForce(ballforce * BallPower, ForceMode.Impulse);
            endline();
        }
                        
    }

    public void Drawlint(Vector3 startpoint, Vector3 endpoint)
    {
        line.positionCount = 2;
        Vector3[] Allpoint = new Vector3[2];
        Allpoint[0] = startpoint;
        Allpoint[1] = endpoint;
        line.SetPositions(Allpoint);
    }

    public void endline()
    {
        line.positionCount = 0;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
    }

}
