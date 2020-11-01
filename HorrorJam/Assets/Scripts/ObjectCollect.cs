using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollect : MonoBehaviour
{
    public bool canCollect;

    // Start is called before the first frame update
    void Start()
    {
        canCollect = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        if (hitColliders.Length > 0)
        {
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    canCollect = true;
                    print("Player can Collect");
                }
            }
        }

        if (Input.GetKeyDown("r")) {
            if (canCollect)
            {
                print("Collected!");
                Destroy(gameObject);
            }
        }
    }
}
