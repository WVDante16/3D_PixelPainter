using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

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

    //Funcion para modificar el volumen de la musica
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    //Funcion para modificar el volumen de los efectos especiales
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
