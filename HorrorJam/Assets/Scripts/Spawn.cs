using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    public GameObject LeftWing;
    [SerializeField]
    public GameObject RightWing;
    [SerializeField]
    public GameObject BasementWing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "leftWing")
            {
                LeftWing.SetActive(true);
            }
            else if(gameObject.name == "rightWing")
            {
                RightWing.SetActive(true);
            }
            else if (gameObject.name == "basementWing")
            {
                BasementWing.SetActive(true);
            }
        }
    }
}
