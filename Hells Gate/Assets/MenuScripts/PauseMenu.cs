using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    public bool gamePaused = false;
    [SerializeField] GameObject pauseMenu;
    public GameManager gameManager;
    public GameObject StatPageUI;

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    void Update()
    {//enables/disables the pause menu 
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false  && StatPageUI.activeSelf == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            gameManager.pauseMenuActive();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == true && StatPageUI.activeSelf == false)
        {
            Time.timeScale = 1;
            gamePaused = false;
            pauseMenu.SetActive(false);
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("menu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gamePaused = false;
        pauseMenu.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        gamePaused = false;
    }
}