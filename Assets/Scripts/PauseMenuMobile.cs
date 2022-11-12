using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuMobile : MonoBehaviour
{
    // Static ya que pertenece solo a esta clase y solo existe una 
    public static bool gameIsPaused = false;

    public GameObject pausedMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Para que cuando apretemos escape vuelva al juego
        pausedMenu.SetActive(false);
        
        // Para que la escena no se pause y avance
        Time.timeScale = 1f;
        //Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
    }

    public void Pause()
    {
        // Para que cuando apretemos escape se pause el juego 
        pausedMenu.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        // Para que se pause el juego
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mobile");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
 }
