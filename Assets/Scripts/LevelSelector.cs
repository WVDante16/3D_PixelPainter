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

        if (level == 1)
        {
            //Instanciar el sonido de salto
            AudioManager.Instance.PlayMusic("Pokemon");
        }
        else if (level == 2)
        {
            //Instanciar el sonido de salto
            AudioManager.Instance.PlayMusic("Stardew");
        }
        else if (level == 3)
        {
            //Instanciar el sonido de salto
            AudioManager.Instance.PlayMusic("Mario");
        }
    }
}
