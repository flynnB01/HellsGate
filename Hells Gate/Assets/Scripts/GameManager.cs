using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseMenu;
    public GameObject statPage;

    // Set this integer to the next level index from build
    public int nextLevel;

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void statPageActive()
    {
        statPage.SetActive(true);
    }
    public void pauseMenuActive()
    {
        pauseMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Gets loads current index
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menu"); // Loads main menu
    }

    public void LoadNextLevel()
    {
        Debug.Log("Loaded next level");
        SceneManager.LoadScene(nextLevel);
    }

    public void Exit()
    {
        SceneManager.LoadScene("menu");
    }

}
