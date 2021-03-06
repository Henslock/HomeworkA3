﻿using UnityEngine;
using System.Collections;

public class EnemyKnight : MonoBehaviour
{

    /*
    Excel Level Assignment - A heat (or rather player) seeking enemy script that moves the enemy towards to player coordinates. It kills the player on contact. 

    Josh Bellyk - 100526009
    Owen Meier  - 100538643    
    */

    public GameObject plr;
    private Player player;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        plr = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (plr)
        {
            if (Vector3.Distance(transform.position, plr.transform.position) <= 3.0f)
            {
                player = plr.GetComponent<Player>();
                if (!player.isDead)
                {
                    transform.position = Vector3.MoveTowards(transform.position, plr.transform.position, 0.02f);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Player player = collision.collider.GetComponent<Player>();

        if (player)
        {
            player.Death();
            
        }
    }
}
