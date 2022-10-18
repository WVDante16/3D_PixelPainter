using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    public Renderer myObject;
    public Material myMaterial;

    public void ChangeColor()
    {
        myObject.material = myMaterial; 
    }
}
