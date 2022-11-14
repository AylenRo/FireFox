using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Se crea la clase irMenu

public class IrMenu : MonoBehaviour
{
    public AudioSource sonidoBoton;
public void EscenaMenu(){
    SceneManager.LoadScene("Menu");//Se carga la escena Menu
        sonidoBoton.Play();
}
public void EscenaCreditos(){
    SceneManager.LoadScene("Credits");//Se carga la escena Credits
        sonidoBoton.Play();
    }

public void Exit(){
   #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;//Si la pantalla está en el editor de unity o juego, sale.
    #else
    Application.Quit();//Sale del juego
    #endif
}
}
