using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AngelMove : MonoBehaviour
{
    public static bool move;
    public static bool roam;
    public float time;
    public float maxDistance;

    public GameObject angel;
    public GameObject player;

    UnityEngine.AI.NavMeshAgent agent;

    public int xmax, zmax, xmin, zmin;
    public Vector3 roamTo;

    // Start is called before the first frame update
    void Start()
    {
        roam = false;
        move = false;
        time = 0;
        maxDistance = 3f;

        xmax = 47;
        zmax = 47;
        xmin = 1;
        zmin = 1;

        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            //time = 1;
            //move = false;

            agent.destination = player.transform.position;
            //print("Moving...");
        }
        else if (roam)
        {
            roamTo = new Vector3(Random.Range(xmin, xmax), 1, Random.Range(zmin, zmax));
            agent.destination = roamTo;
            //print("Roaming...");
        }
        else
        {
            agent.destination = angel.transform.position;
            //print("Freezing...");
        }

        if (angel.transform.position.x <= player.transform.position.x + 1 || angel.transform.position.x <= player.transform.position.x - 1)
        {
            if (angel.transform.position.z <= player.transform.position.z + 1 || angel.transform.position.z <= player.transform.position.z - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
