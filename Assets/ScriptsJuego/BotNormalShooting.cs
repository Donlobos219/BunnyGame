﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class BotNormalShooting : MonoBehaviour
{

    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 20.0f;

    private bool onRange = false;

    public Rigidbody projectile;

    void Start()
    {
        float rand = Random.Range(3.0f, 4.0f);
        InvokeRepeating("Shoot", 4, rand);
    }

    void Shoot()
    {

        if (onRange)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);

            Destroy(bullet.gameObject, 5);
        }


    }

    void Update()
    {

        onRange = Vector3.Distance(transform.position, player.position) < range;

    }


}