using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Funcion para dirigir al usuario a la seleccion de niveles
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //Funcion para salir del juego
    public void QuitGame()
    {
        Application.Quit();
    }

    //Funcion para reiniciar el nivel
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
