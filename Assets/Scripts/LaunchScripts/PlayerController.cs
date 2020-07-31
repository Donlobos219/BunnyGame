using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Dweiss;

[RequireComponent(typeof(LineRenderer))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private LineRenderer line;
    public bool canLaunch = true;
    public bool bunnyInAir = false;
    public float baseLaunchForce = 20;
    public float pushForce = 2;

    public Rigidbody bunny;

    public float minAngle = 0.3f;

    public AudioSource salto;

    [Header("LineRendererLaunch")]
    public int linePoints = 4;

    public float linespacing = 1;
    private Vector3 launchForce;
    private Vector3 pushBunny;
    private Vector3[] res;

    public float min = -35;
    public float max = 45;

    public float cameraRot;

    bool onGround = true;
    // Start is called before the first frame update

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        LeanTouch.OnFingerSet += OnFingerSet;
        LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
        LeanTouch.OnFingerDown += LeanTouch_OnFingerTap;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerSet -= OnFingerSet;
        LeanTouch.OnFingerUp -= LeanTouch_OnFingerUp;
        LeanTouch.OnFingerTap += LeanTouch_OnFingerTap;
    }

    private void LeanTouch_OnFingerUp(LeanFinger finger)
    {
        LaunchBunny();
        
    }

    private void LeanTouch_OnFingerTap(LeanFinger finger)
    {
        //PushBunny();
    }

    private void PushBunny()
    {

        //if (!canLaunch && onGround) return;

        canLaunch = true;
        bunny.velocity = pushBunny;
        bunnyInAir = true;


    }

    private void LaunchBunny()
    {
        Rotate();
        if (onGround)
        {
            //if (!canLaunch && onGround) return;
            canLaunch = true;
            bunny.velocity = launchForce;
            line.positionCount = 0;
            bunnyInAir = true;
            salto.Play();
        }
    }

    private void OnFingerSet(LeanFinger finger)
    {
        

        //if (!canLaunch) return;
        
        Rotate();
        
        
            Vector2 bunnyScreenPosition = Camera.main.WorldToScreenPoint(bunny.transform.position);
            //Vector2 bunnyScreenPositionUp = Camera.main.WorldToScreenPoint(bunny.transform.position);

        //finger.GetScaledDistance();
            float dragDistance = finger.GetScreenDistance(bunnyScreenPosition) * .1f;
            dragDistance = Mathf.Clamp(dragDistance, min, max);

            //float dragDistanceUp = finger.GetScreenDistance(bunnyScreenPositionUp) * .1f;
            //dragDistanceUp = Mathf.Clamp(dragDistance, min, max);


            if (finger.LastScreenPosition.y > bunnyScreenPosition.y)
                dragDistance = 0;

            //if (finger.LastScreenPosition.y < bunnyScreenPositionUp.y)
                //dragDistanceUp = 1;

            Vector3 viewportPosition = Camera.main.ScreenToViewportPoint(finger.LastScreenPosition);

            float xRot = Mathf.Lerp(1, -1, viewportPosition.x);
        


            if (Mathf.Abs(xRot) > 0.3f)
                bunny.transform.RotateAround(transform.position, Vector3.down, xRot * cameraRot * Time.deltaTime);





            transform.rotation = bunny.transform.rotation;
            DrawMovementLine(dragDistance);

            //transform.rotation = bunny.transform.rotation;
            //DrawMovementLineDown(dragDistanceUp);

    }

    


    private void DrawMovementLine(float DragDistance)
    {
        
        Rotate();


        if(onGround)
        { 
        launchForce = bunny.transform.forward + Vector3.up;
        
        launchForce *= DragDistance + baseLaunchForce * Time.deltaTime;
        
        res = bunny.CalculateMovement(linePoints, linespacing, launchForce);
        

        line.positionCount = linePoints + 1;
        line.SetPosition(0, bunny.transform.position);
            for (int i = 0; i < res.Length; ++i)
            {
                line.SetPosition(i + 1, res[i]);
            }
        }
    }

    

    private void CheckBunnyStoppped()
    {
        if (bunny.IsSleeping())
        {
            canLaunch = true;
            bunnyInAir = false;
            return;
        }

        transform.position = bunny.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (bunnyInAir)
            CheckBunnyStoppped();
    }

    void Rotate()
    {

        RaycastHit hit;
        Vector3 physicsCentre = this.transform.position + this.GetComponent<CapsuleCollider>().center;
        if (Physics.Raycast(physicsCentre, Vector3.down, out hit, 1.5f))
        {
            onGround = true;

        }
        else
        {
            onGround = false;
        }
    }
}