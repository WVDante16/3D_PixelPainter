using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    //Variables privadas
    private ParticleSystem thisParticleSystem; //Referencia al particleSystem

    private void Start()
    {
        //Inicializar la referencia thisParticleSystem
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        //Llamar a la funcion para destruir particulas
        DestroyParticleSystem();
    }

    void DestroyParticleSystem()
    {
        //Checar si el emisor de particulas esta en reproduccion
        if (thisParticleSystem.isPlaying)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
