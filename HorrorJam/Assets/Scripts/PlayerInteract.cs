using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 2f;
    public GameObject current=null;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.green);

        //if (Physics.Raycast(transform.position, transform.forward, out RaycastHit _hit, interactDistance) && !PlayerState.instance.busy && !PlayerState.instance.paused)  //do we hit something?
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit _hit, interactDistance))  //do we hit something?
        {
            GameObject obj = _hit.collider.gameObject;

            if (current != obj)               //are we looking at something new?
            {
                InteractionController interaction = _hit.collider.gameObject.GetComponent<InteractionController>();

                if (interaction != null )       //is it interactable?
                {
                    if (current !=null)     //deactivate outline if possible
                    {
                        current.GetComponent<InteractionController>().outline.disable();
                    }
                    current = obj.gameObject;   //transfer current;
                    interaction.gameObject.GetComponent<OutlineController>().outline();
                }
                else if (current !=null)    //we are now looking at something not interactable, disable outline if possible
                {
                    current.GetComponent<InteractionController>().outline.disable();
                    current = null;
                }
            }
            else   //check if we are clicking
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    current.GetComponent<InteractionController>().Activate();
                }
            }
        }
        else if (current != null)   //if nothing hits, deactivate outline if possible
        {
            current.GetComponent<InteractionController>().outline.disable();
            current = null;
        }
    }
}
