using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //base case of '1'
    public static int loadSavedGame = 1;
    public static bool newGame;
    public static bool loadGame;

    public void PlayGame()
    {
        Debug.Log("Game Start");
        //game starts and case '3' is activated
        //loadSavedGame = 3;
        newGame = true;
        SceneManager.LoadScene(1);
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
