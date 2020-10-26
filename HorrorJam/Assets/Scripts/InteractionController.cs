using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionController : MonoBehaviour
{
    public UnityEvent actions;
    public OutlineController outline;
    
    public void Activate()
    {
        actions.Invoke();
    }
}
