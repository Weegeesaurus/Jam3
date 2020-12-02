using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelControl : MonoBehaviour
{
    public Renderer playerVision;
    public bool visible;
    public bool roaming;
    public GameObject angel;
    public GameObject player;
    UnityEngine.AI.NavMeshAgent agent;
    public int xmax, zmax, xmin, zmin;
    public float time;
    public Vector3 roamTo;

    public int killRadius;
    public int followRadius;
    public int visionRadius;

    // Start is called before the first frame update
    void Start()
    {
        playerVision = gameObject.GetComponent<Renderer>();

        roaming = false;
        angel = gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();

        xmax = 68;      // 35  47
        zmax = 20;      // 44  47
        xmin = -60;     // -48  1
        zmin = -59;     // -20  1

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (roaming)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            if (time <= 0 || angel.transform.position == roamTo)
            {
                time = 10;
                roamTo = new Vector3(Random.Range(xmin, xmax), angel.transform.position.y, Random.Range(zmin, zmax));
                agent.destination = roamTo;
            }
        }
        else
        {
            time = 0;
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Linecast(angel.transform.position, player.transform.position, out hit);
        //print(hit.transform.tag);
        //print(playerVision.isVisible);
        //print(Vector3.Distance(angel.transform.position, player.transform.position) <= visionRadius);
        
        if (playerVision.isVisible && (hit.transform.tag == "Player" || hit.transform.tag == "door") && Vector3.Distance(angel.transform.position, player.transform.position) <= visionRadius)
        {
            roaming = false;
            agent.destination = angel.transform.position;
            //print("Freezing...");
        }
        else
        {
            if (Vector3.Distance(angel.transform.position, player.transform.position) <= followRadius && (hit.transform.tag == "Player" || hit.transform.tag == "door"))
            {
                //print("Following...");
                roaming = false;
                agent.destination = player.transform.position;
                //print("Destination: " + agent.destination);
            }
            else
            {

                //print("Roaming...");
                roaming = true;
            }

        }
    }
}
