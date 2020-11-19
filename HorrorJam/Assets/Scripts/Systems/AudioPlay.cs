using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public static AudioPlay instance;
    public GameObject[] soundPrefabs;

    private void Awake()    //setting up singleton
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Inventory already exists, destroying object!");
            Destroy(this);
        }
    }

    public static void PlaySound(int id)
    {
        GameObject obj = Instantiate(AudioPlay.instance.soundPrefabs[id]);
        Destroy(obj, 5f);
    }

    public static void PlaySound(int id,Transform pos)
    {
        GameObject obj = Instantiate(AudioPlay.instance.soundPrefabs[id],pos,true);
        Destroy(obj, 5f);
    }

    public static void PlaySound(int id, Vector3 pos, Quaternion rotation)
    {
        GameObject obj = Instantiate(AudioPlay.instance.soundPrefabs[id], pos,rotation);
        Destroy(obj, 5f);
    }
}
