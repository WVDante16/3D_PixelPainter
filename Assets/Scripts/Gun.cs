using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Variables publicas
    public float range = 100f; //Rango del disparo
    public Camera fpsCam;
    public string colorSelect = "";

    //Variables privadas
    private bool shooting = false;
    private bool changing = false;

    private void Update()
    {
        //Disparo
        if (/*Input.GetButtonDown("Fire1") ||*/ shooting == true)
        {
            Shoot();
            shooting = false;
        }

        //Cambio de color
        if (/*Input.GetButtonDown("Fire2") ||*/ changing == true)
        {
            SelectColor();
            changing = false;
        }
    }

    //Funcion para disparar
    void Shoot()
    {
        RaycastHit hit;
        
        //Funcion que dispara un raycast desde la camara que regresa un true / false
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            ChangeMaterialColor change = hit.transform.GetComponent<ChangeMaterialColor>();
            
            //Comprobacion y ejecucion del cambio de color
            if (change != null && hit.transform.tag == colorSelect)
            {
                change.ChangeColor();
            }
        }
    }

    //Funcion para intercambiar color (tag)
    void SelectColor()
    {
        RaycastHit hitColor;

        //Funcion para disparar un raycast desde la camara que regresa un true / false
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitColor, range))
        {
            if (hitColor.transform.tag != null && hitColor.transform.tag != "Untagged" && hitColor.transform.tag != "Ground")
            {
                colorSelect = hitColor.transform.tag;
            }
        }
    }

    //Funcion que interactua con el boton de disparo
    public void ButtonShoot()
    {
        shooting = true;
    }

    //Funcion que interactua con el boton de cambiar color
    public void ButtonChangeColor()
    {
        changing = true;
    }
}
