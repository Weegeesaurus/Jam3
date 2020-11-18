using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    DateTime curTime;
    GameObject player;
    GameObject targetRoom;
    System.Random RNGenie;

    [SerializeField] float minFlick;
    [SerializeField] float maxFlick;
    float z;
    int seed;
    int roomSelection;

    //Time the lights spend flickering
    [Range(0, 600)] [SerializeField] int flickerTime;

    //Light Arrays and an Array to List the Rooms
    Light[] roomLights;
    readonly string[] ROOMLIST = {"entryWay", "operatingRoom", "operating2", "checkIn", "medSupply", 
        "upstairsOffice", "kitchen", "cafeteria", "showers", "lounge", "cellA", "cellB", "cellD", "cellE",
        "cellF", "cellG", "cellH", "pantry", "bathroom"};

    //Good ol' start function
    IEnumerator Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Start function WaitAndPrint as a coroutine
        yield return StartCoroutine("FlickLight");
    }

    // A coroutine that will disable the lights after a fixed amount of time
    IEnumerator FlickLight()
    {
        float theTime = Time.time;

        //Selects a random room
        RNGenie = new System.Random(SeedGenerator());
        roomSelection = RNGenie.Next(0, ROOMLIST.Length - 1);
        Debug.Log(roomSelection);
        targetRoom = GameObject.FindGameObjectWithTag(ROOMLIST[roomSelection]);        

        //Sets all the lights associated with that object into an array
        roomLights = targetRoom.GetComponentsInChildren<Light>();

        //Finds a room with lights on then turns each of them off.
        if (roomLights[0].intensity != 0)
        {

            while (Time.time < theTime + flickerTime)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(minFlick, maxFlick));
                for (int i = 0; i < roomLights.Length; i++)
                {
                    roomLights[i].enabled = !roomLights[i].enabled;
                }
            }
        }
        else
        {
            Debug.Log("Recursion Called");
            yield return FlickLight();
        }
    }

/*
The SeedGenerator function returns an integer that is based on:
        The ratio of the character's x and z coordinates
        The current milliseconds on the clock
        The number of frames since the start of the game
        The amount of time that passed between frames
        The mouse position on screen
*/
private int SeedGenerator()
    {
        curTime = DateTime.Now;
        z = player.transform.position.z;

        seed = (int)math.floor(curTime.Millisecond / (Time.frameCount * Time.deltaTime));
        if (player.transform.position.z == 0)
        {
            z = player.transform.position.z + 1;
        }

        seed = seed * (int)math.floor(Input.mousePosition.magnitude * (player.transform.position.x / z));
        return seed;
    }
}