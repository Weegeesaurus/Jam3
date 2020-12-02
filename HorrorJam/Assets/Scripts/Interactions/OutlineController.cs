using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    public Material outlineMaterial;
    public float outlineThickness;
    public Color outlineColor;
    public bool FlipOutline;
    private Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = CreateOutline(outlineMaterial, outlineThickness, outlineColor);
        render.enabled = false;
    }
    public void outline()
    {
        render.enabled = true;
    }
    public void disable()
    {
        render.enabled = false;
    }

    Renderer CreateOutline(Material mat, float thickness, Color color)
    {
        GameObject outlineObj = Instantiate(this.gameObject,transform.position, transform.rotation);
        outlineObj.transform.parent = gameObject.transform;
        if (FlipOutline)
        {
            outlineObj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            outlineObj.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        outlineObj.transform.localScale = new Vector3(1, 1, 1);
        Renderer rend = outlineObj.GetComponent<Renderer>();
        rend.material = mat;
        rend.material.SetColor("_color", color);
        rend.material.SetFloat("_thickness", thickness);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObj.GetComponent<OutlineController>().enabled = false;
        outlineObj.GetComponent<Collider>().enabled = false;

        InteractionController temp = outlineObj.GetComponent<InteractionController>();
        if (temp != null)
        {
            temp.enabled = false;
        }

        return rend;

    }
}
