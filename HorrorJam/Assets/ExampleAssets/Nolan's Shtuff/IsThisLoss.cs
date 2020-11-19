using System.Collections;
using UnityEngine;

public class IsThisLoss : MonoBehaviour
{
    GameObject targetRoom;
    [SerializeField] float minFlick;
    [SerializeField] float maxFlick;

    int roomSelection;
    float waitTime;
    int counter;
    bool lightFinished;

    //Time the lights spend flickering
    [Range(0, 60)] [SerializeField] int flickerTime;
    [SerializeField] float firstFlick;
    [Tooltip("Time(in seconds) between the loading of the level and the first room flickering")]
    [SerializeField] float repeatFlick;
    [Tooltip("Time(in seconds) between the previous room flickering and the next")]

    GameObject player;

    //Light Arrays and an Array to List the Rooms
    Light[] roomLights;
    readonly string[] ROOMLIST = {"entryWay", "operatingRoom", "operating2", "checkIn", "medSupply",
       "upstairsOffice", "kitchen", "cafeteria", "showers", "lounge", "cellA", "cellB", "cellE",
       "cellF", "cellG", "cellH", "pantry", "bathroom"};

    //Good ol' start function
    void Start()
    {
        counter = 0;
        lightFinished = false;
        Debug.Log(ROOMLIST.Length);
        player = GameObject.FindGameObjectWithTag("Player");
        // Start function WaitAndPrint as a coroutine
        waitTime = firstFlick;
        StartCoroutine("FlickLight");
    }

    // A coroutine that will disable the lights after a fixed amount of time
    IEnumerator FlickLight()
    {
        waitTime = repeatFlick;
        float theTime = Time.time;

        //Selects a random room
        roomSelection = Random.Range(0, ROOMLIST.Length);
        Debug.Log(ROOMLIST[roomSelection]);
        targetRoom = GameObject.Find(ROOMLIST[roomSelection]);

        //Sets all the lights associated with that object into an array
        roomLights = targetRoom.GetComponentsInChildren<Light>();

        //Finds a room with lights on then turns each of them off.
        if (roomLights[0].enabled)
        {
            yield return new WaitForSeconds(waitTime);
            while (Time.time < theTime + flickerTime)
            {
                yield return new WaitForSeconds(Random.Range(minFlick, maxFlick));
                for (int i = 0; i < roomLights.Length; i++)
                {
                    roomLights[i].enabled = !roomLights[i].enabled;
                }
            }
            for (int i = 0; i < roomLights.Length; i++)
            {
                roomLights[i].enabled = false;
            }
            counter++;
            yield return FlickLight();
        }
        else if (counter < ROOMLIST.Length)
        {
            yield return FlickLight();
        }
        //else if (!lightFinished)
        //{
        //    string[] ROOMLIST = {"hallway"};
        //    lightFinished = true;
        //    yield return FlickLight();
        //}
        else
        {
            Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            WinLoss.gameLose = true;
        }
    }*/
}