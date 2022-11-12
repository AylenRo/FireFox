using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Se crea la clase Menu
public class Menu : MonoBehaviour
{
public void EscenaJuego(){
    SceneManager.LoadScene("SampleScene");//Empieza la escena del juego.
}
}
