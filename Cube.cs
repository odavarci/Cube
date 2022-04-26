using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    Color color = new Color(0,0,0,1);
    Material material;
    bool raiseColor = true, raiseScale = true;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.zero;
        
        material = Renderer.material;
        material.color = color;
        InvokeRepeating("ChangeColor", 0, 0.1f);
        InvokeRepeating("ChangeScale", 0, 0.1f);
    }
    
    void Update()
    {
        transform.Rotate(50.0f * Time.deltaTime, 0.0f, 0.0f);
    }

    //Color values go from 0 to 1 and then 1 to 0.
    void ChangeColor()
    {
        float newColorValue;
        if(raiseColor)
        {
            newColorValue = color[0] + 0.01f;
            if(newColorValue >= 1)
            {
                raiseColor = false;
            }
        }
        else
        {
            newColorValue = color[0] - 0.01f;
            if(newColorValue <= 0)
            {
                raiseColor = true;
            }
        }
        color = new Color(newColorValue,newColorValue,newColorValue,1);
        material.color = color;
    }

    void ChangeScale(){
        Vector3 toBeAdd = new Vector3(0.01f,0.01f,0.01f);
        if(!raiseScale)
        {
            toBeAdd = -toBeAdd;
        }
        transform.localScale = transform.localScale + toBeAdd;
        Debug.Log(transform.localScale);
        if(transform.localScale.x <= 0 || transform.localScale.x >= 2)
        {
            raiseScale = !raiseScale;
        }
    }
}
