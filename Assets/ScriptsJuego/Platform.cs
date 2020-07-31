using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject player;
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
