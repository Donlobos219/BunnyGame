using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody m_rb;

    public float gravityScale = 8.0f;

    public static float globalGravity = -9.81f;

    public bool hasKey = false;

    public GameObject replacement;

    public TimeManagerSlowMotion timeManager;

    private float fixedDeltaTime;

    public AudioSource fallar;

    public AudioSource source;

    public AudioClip[] suelo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
    }


// Update is called once per frame
    void Awake ()
        {
            this.fixedDeltaTime = Time.fixedDeltaTime;
        }
void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Key")
        {
            hasKey = true;
            Destroy(other.gameObject);

        }

        if(other.gameObject.CompareTag("Door") && hasKey==true)
        {
            other.GetComponent<DoorScript>().OpenDoor();

        }

        if (other.gameObject.tag == ("Nivel1"))
        {
            SceneManager.LoadScene("Nivel2Final");
        }


        if (other.gameObject.tag == ("Nivel2"))
        {
            SceneManager.LoadScene("Nivel3Final");
        }

        if (other.gameObject.tag == ("Nivel3"))
        {
            SceneManager.LoadScene("Nivel4Final");

        }

        if (other.gameObject.tag == ("Nivel4"))
        {
            SceneManager.LoadScene("Nivel6Final");
        }

        if (other.gameObject.tag == ("Nivel6"))
        {
            SceneManager.LoadScene("Final");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == ("DestroyTriggerTutorial"))
        {
            //SceneManager.LoadScene(1);
            //Destroy(this.gameObject);
        }

        //if (collision.gameObject.tag == ("DestroyTrigger1"))
        {
            //SceneManager.LoadScene(3);
            //Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == ("Suelo"))
        {
            source.clip = suelo[Random.Range(0, suelo.Length)];
            source.Play();
        }

        if (collision.gameObject.tag == ("Roca"))
        {
            source.clip = suelo[Random.Range(0, suelo.Length)];
            source.Play();
        }


        if (collision.gameObject.tag == ("DestroyTriggerNivel4"))
        {
            //SceneManager.LoadScene("Nivel4Final");
            Destroy(this.gameObject);
            GameObject.Instantiate(replacement, transform.position, transform.rotation);
            fallar.Play();
            //if (Time.timeScale == 1.0f)
            
                //timeManager.DoSlowmotion();
            //else          
                //timeManager.RealTime();
                //Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }   

}
