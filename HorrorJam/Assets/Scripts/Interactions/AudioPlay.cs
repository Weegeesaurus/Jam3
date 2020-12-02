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

    public static void PlaySound(int id, float duration)
    {
        GameObject obj = Instantiate(AudioPlay.instance.soundPrefabs[id]);
        obj.transform.parent = null;
        Destroy(obj, duration);
    }

    public static void PlaySound(int id,Transform pos, float duration)
    {
        GameObject obj = Instantiate(AudioPlay.instance.soundPrefabs[id],pos,true);
        obj.transform.parent = null;
        obj.transform.position = pos.position;
        Destroy(obj, duration);
    }

    public static void PlaySound(int id, Vector3 pos, Quaternion rotation, float duration)
    {
        GameObject obj = Instantiate(AudioPlay.instance.soundPrefabs[id], pos,rotation);
        obj.transform.parent = null;
        obj.transform.position = pos;
        Destroy(obj, duration);
    }
}
