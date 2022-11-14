using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CongratulationsMobile : MonoBehaviour
{
  
    //colision usando el tag
    private void OnTriggerEnter(Collider other)
    {

        //condicion para ganar
        if (other.gameObject.CompareTag("VictoryMobile")) {
            WinGame();
            Destroy(other.gameObject);
            
        } 
    }


        private void WinGame()
        {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Recomendations");

    }


    } 
