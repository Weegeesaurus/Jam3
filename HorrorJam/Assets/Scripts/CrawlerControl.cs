﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrawlerControl : MonoBehaviour
{
    private bool playerMoving;
    private bool roaming;
    public GameObject crawler;
    public GameObject player;
    public int xmax, zmax, xmin, zmin;
    public float time;
    public Vector3 roamTo;

    UnityEngine.AI.NavMeshAgent agent;
    private Animator controller;

    [SerializeField]
    public int killRadius;
    public int followRadius;

    // Start is called before the first frame update
    void Start()
    {
        playerMoving = false;
        roaming = false;
        crawler = gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();
        controller = GetComponent<Animator>();

        xmax = 47;      // 35
        zmax = 47;      // 44
        xmin = 1;     // -48
        zmin = 1;     // -20

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            playerMoving = true;
        }
        else
        {
            playerMoving = false;
        }

        if (roaming)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            if (time <= 0 || crawler.transform.position == roamTo)
            {
                time = 10;
                roamTo = new Vector3(Random.Range(xmin, xmax), crawler.transform.position.y, Random.Range(zmin, zmax));
                agent.speed = 2;
                agent.destination = roamTo;
            }
            if (controller.GetCurrentAnimatorStateInfo(0).IsName("crawl_fast"))
            {
                controller.SetTrigger("Roam");
            }
        }
        else
        {
            time = 0;
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(crawler.transform.position, player.transform.position) <= followRadius)
        {
            if (playerMoving)
            {
                //print("I see you...");
                roaming = false;
                agent.destination = player.transform.position;
                agent.speed = 8;
                controller.SetTrigger("Follow");

                if (Vector3.Distance(crawler.transform.position, player.transform.position) <= killRadius)
                {
                    // Uncomment for build
                    //WinLoss.gameLose = true;
                    controller.SetTrigger("Attack");
                    print("Lose!");
                }
            }
            else
            {
                //print("Can't hide forever...");
                roaming = true;
            }
        }
        else
        {
            //print("I'll find you...");
            roaming = true;
        }
    }
}
