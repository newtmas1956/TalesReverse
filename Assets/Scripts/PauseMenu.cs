using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pauseGame;
    public GameObject pauseGameMenu;

   /* void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (pauseGame)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Continue()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
