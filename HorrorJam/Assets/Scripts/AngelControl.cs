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

    [SerializeField]
    public int killRadius;
    public int followRadius;

    // Start is called before the first frame update
    void Start()
    {
        playerVision = gameObject.GetComponent<Renderer>();

        roaming = false;
        angel = gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();

        xmax = 47;      // 35
        zmax = 47;      // 44
        xmin = 1;     // -48
        zmin = 1;     // -20

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
        if (playerVision.isVisible && hit.transform.tag == "Player")
        {
            roaming = false;
            agent.destination = angel.transform.position;
            print("Freezing...");
        }
        else
        {
            if (Vector3.Distance(angel.transform.position, player.transform.position) <= followRadius && hit.transform.tag == "Player")
            {
                print("Following...");
                roaming = false;
                agent.destination = player.transform.position;
                print("Destination: " + agent.destination);
            }
            else
            {

                print("Roaming...");
                roaming = true;
            }

        }
    }
}
