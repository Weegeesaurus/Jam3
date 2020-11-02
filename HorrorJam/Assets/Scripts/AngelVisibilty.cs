using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelVisibilty : MonoBehaviour
{
    public Renderer playerVision;
    public bool visible;

    // Start is called before the first frame update
    void Start()
    {
        playerVision = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (playerVision.isVisible)
        {
            // print("Hit!");
            AngelMove.move = false;
            AngelMove.roam = false;
        }
        else
        {
            //print("Miss!");

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 25f);
            if (hitColliders.Length > 0)
            {
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Player"))
                    {
                        //print("Hit!");
                        //transform.position = Vector3.MoveTowards(transform.position, hitCollider.transform.position, .05f);
                        AngelMove.move = true;
                        AngelMove.roam = false;
                    }
                    else
                    {
                        AngelMove.move = false;
                        AngelMove.roam = true;
                    }
                }
            }
            else
            {
                AngelMove.move = false;
                AngelMove.roam = true;
            }
        }


    }
}
