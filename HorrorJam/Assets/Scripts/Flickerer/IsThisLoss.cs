using System.Collections;
using UnityEngine;

public class IsThisLoss : MonoBehaviour
{
    GameObject targetRoom;
    [SerializeField] float minFlick;
    [SerializeField] float maxFlick;

    int roomSelection;
    float waitTime;

    //Time the lights spend flickering
    [Tooltip("Time(in seconds) the lights in a room will spend flickering")]
    [Range(0, 60)] [SerializeField] int flickerTime;
    [Tooltip("Time(in seconds) between the loading of the level and the first room flickering")]
    [SerializeField] float firstFlick;
    [Tooltip("Time(in seconds) between the previous room flickering and the next")]
    [SerializeField] float repeatFlick;
    
    //Tracks iterations through the ROOMLIST
    int counter;

    //Holds onto the colliders in a room to search for the one with a trigger
    Collider[] colliders;
    
    //Light Arrays and an Array to List the Rooms
    Light[] roomLights;
    readonly string[] ROOMLIST = {"entryWay", "operatingRoom", "operating2", "checkIn", "medSupply",
       "upstairsOffice", "kitchen", "cafeteria", "showers", "lounge", "cellA", "cellB", "cellE",
       "cellF", "cellG", "cellH", "pantry", "bathroom"};

    //Starts FlickLight coroutine after setting the inital wait time value
    void Start()
    {
        waitTime = firstFlick;
        StartCoroutine("FlickLight");
    }

    // A coroutine that will disable the lights after a fixed amount of time
    IEnumerator FlickLight()
    {
        //Selects a random room, unless every ROOMLIST room has been turned off
        if (counter == (ROOMLIST.Length - 1))
        {
            targetRoom = GameObject.Find("hallway");
        }
        else
        { 
            roomSelection = Random.Range(0, ROOMLIST.Length - 1);
            targetRoom = GameObject.Find(ROOMLIST[roomSelection]);
        }
        //Sets all the lights associated with that object into an array
        roomLights = targetRoom.GetComponentsInChildren<Light>();
        
        //Finds a room with lights on then turns each of them off.
        if (roomLights[0].intensity != 0.0f)//Checks if the lights in the selected room are on
        {
            yield return new WaitForSeconds(waitTime);
            waitTime = repeatFlick;//Sets the waitTime for the while loop
            float theTime = Time.time;//Local variable used to judge how long the lights should flicker

            //Checks current time against local variable plus the flickerTime to exit the loop
            while (Time.time < theTime + flickerTime)
            {
                //Enables and disables the lights for the time set in the Inspector
                yield return new WaitForSeconds(Random.Range(minFlick, maxFlick));
                for (int i = 0; i < roomLights.Length; i++)
                {
                    roomLights[i].intensity = Random.Range(0.0f, 10.0f);
                }
            }

            //After flickering, this for loop turns off all the lights
            for (int i = 0; i < roomLights.Length; i++)
            {
                roomLights[i].intensity = 0.0f;
            }
            counter++;

            //Enables the colliders that will kill the player for loitering in a room
            colliders = GameObject.Find(ROOMLIST[roomSelection]).GetComponentsInChildren<Collider>(true);
            foreach (Collider i in colliders)
            {
                if (i.isTrigger)
                {
                    i.enabled = !(i.enabled);
                    yield return new WaitForSeconds(0.5f);
                    i.enabled = !(i.enabled);
                }
            }

            //Recursively calls the coroutine again to turn off the next light
            yield return FlickLight();
        }

        //Will reiterate through the room list until every room has its lights turned off
        else if(counter <= (ROOMLIST.Length - 1))
        {
            yield return FlickLight();
        }

        //Once every light is turned off, the object with the script is destroyed
        else
        {
            Destroy(gameObject);
        }
    }
}