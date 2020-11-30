using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AngelMove1 : MonoBehaviour
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

    [SerializeField]
    public int killRadius;

    // Start is called before the first frame update
    void Start()
    {
        roam = false;
        move = false;
        time = 0;
        maxDistance = 3f;

        xmax = 35;      // 35
        zmax = 44;      // 44
        xmin = -48;     // -48
        zmin = -20;     // -20

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

            //if (angel.transform.position.x <= player.transform.position.x + killRadius || angel.transform.position.x >= player.transform.position.x - killRadius)
            if (Vector3.Distance(angel.transform.position, player.transform.position) <= killRadius)
            {
                //if (angel.transform.position.z <= player.transform.position.z + killRadius || angel.transform.position.z >= player.transform.position.z - killRadius)
                //{
                    // Uncomment for build
                    WinLoss.gameLose = true;
                //}
            }
            //print("Moving...");
        }
        else if (roam)
        {
            //    // timer set new roaming position
            //    time = 10;

            agent.destination = player.transform.position;

            //    roamTo = new Vector3(Random.Range(xmin, xmax), angel.transform.position.y, Random.Range(zmin, zmax));
            //    agent.destination = roamTo;
            //    //print("Roaming...");
        }
        else
        {
            agent.destination = angel.transform.position;
            FindObjectOfType<AudioManager>().play("Enemy1");
            //print("Freezing...");
        }
    }
}
