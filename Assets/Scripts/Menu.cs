using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Se crea la clase Menu
public class Menu : MonoBehaviour
{
    public AudioSource sonidoBoton;
public void EscenaJuego(){
    SceneManager.LoadScene("Mobile", LoadSceneMode.Single);//Empieza la escena del juego.
        sonidoBoton.Play();
    }
}
