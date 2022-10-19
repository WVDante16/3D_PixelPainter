using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    //Variables publicas
    public int level; //Identificador

    //Funcion encargada de abrir el nivel seleccionado
    public void OpenScene()
    {
        SceneManager.LoadScene("Level_" + level.ToString());
    }
}
