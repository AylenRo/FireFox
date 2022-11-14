using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RDG;

public class DetectorDeColisiones : MonoBehaviour
{
    public AudioSource choque;
    public Transform respawnPoint;
   

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Fuego"){
            choque.Play();
            Vibration.Vibrate(1000);
            SceneManager.LoadScene("Mobile");
        }
        
    }

}

