using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionController : MonoBehaviour
{
    public UnityEvent actions;
    public OutlineController outline;
    private Transform player;
    public float interactionDist = 2f;
    public bool eKeyDisabled=false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position)<=interactionDist)
        {
            outline.outline();
            if (Input.GetKeyDown(KeyCode.E) && !eKeyDisabled)
            {
                Activate();
            }
        }
        else
        {
            outline.disable();
        }
    }
    
    public void Activate()
    {
        actions.Invoke();
    }
}
