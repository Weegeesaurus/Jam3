using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public float openSpeed = 3f;
	public float openAngle = 90f;
	public bool pivotClockwise = false;
	public bool open = false;
	private float startingPos = 0;
	private Quaternion target;

    public AudioSource sound;

	void Start()
	{
        sound = GetComponent<AudioSource>();
		startingPos = transform.eulerAngles.y;
	}
	void FixedUpdate () 
	{
		if (open)
        {
			if (pivotClockwise)
            {
				target = Quaternion.Euler(0, startingPos + openAngle, 0);
			}else
            {
				target = Quaternion.Euler(0, startingPos - openAngle, 0);
			}
			
		}
		else
        {
			target = Quaternion.Euler(0, startingPos, 0);
		}

		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * openSpeed);
	}
	public void Open()
	{
		open = true;

        FindObjectOfType<AudioManager>().play("Creek");

	}

	void OnDrawGizmos()
	{
		// Draw a yellow sphere at the transform's position
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, .1f);
	}
}
