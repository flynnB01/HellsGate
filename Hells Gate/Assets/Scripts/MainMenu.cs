using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool newGame;
    public static bool loadGame;

    public void PlayGame()
    {
        Debug.Log("Game Start");

        newGame = true;
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Exited Game");
        Application.Quit();
    }

    public void LoadGame()
    {
        Debug.Log("Game Loaded");
        loadGame = true;

        playerData data = SaveSystem.LoadPlayer();

        SceneManager.LoadScene(data.sceneID);
    }

    public void LoadTest()
    {
        Debug.Log("Game Loaded");
        SceneManager.LoadScene("test area");
    }
}
