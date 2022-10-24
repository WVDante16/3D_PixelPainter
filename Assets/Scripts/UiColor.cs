using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiColor : MonoBehaviour
{
    //Variables publicas
    public Text number;
    public Gun gun; //Referencia al script "Gun"
    public Image myImage;
    public Material[] colors;

    public int seleccion;

    private void Start()
    {
        gun = FindObjectOfType<Gun>();
    }

    private void Update()
    {
        //Llamada al metodo de cambiar numero
        ChangeNumber();

        //Llamada al metodo de cambiar color
        ChangeColor();
    }

    //Metodo para cambair el numero del color seleccionado en la UI
    void ChangeNumber()
    {
        number.text = gun.colorSelect;
    }

    //Metodo para cambiar el color seleccionado en la UI
    void ChangeColor()
    {
        if (gun.colorSelect != "")
        {
            seleccion = int.Parse(gun.colorSelect);
            myImage.material = colors[seleccion- 1];
        }
    }
}
