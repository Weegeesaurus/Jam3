using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    public float speed;
    public Image img;
    private bool active=false;
    // Start is called before the first frame update
    public void FadeOut()
    {
        img.color = new Color(img.color.r,img.color.g, img.color.b,0);
        active = true;
        speed = 2;
    }

    public void FadeIn()
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
        speed = -4;
        active = true;
        Debug.Log("starting fade");
    }
    void Update()
    {
        if (active)
        {
            float a = img.color.a;
            a += Time.deltaTime/speed;
            img.color = new Color(img.color.r, img.color.g, img.color.b, a);
            if (a>1 || a<0)
            {
                Destroy(gameObject);
            }
        }
    }
}
