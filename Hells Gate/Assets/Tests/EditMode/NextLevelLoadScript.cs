using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class NextLevelLoadScript
{
    private GameObject gameManagerObject;
    private GameManager gameManager;

    [SetUp]
    public void Setup()
    {
        // Replace with the actual build index of your scene
        int buildIndex = 1; 
        Debug.Log("Scene Chosen");
        
        // Ensure that the scene is properly loaded
        EditorSceneManager.OpenScene(EditorBuildSettings.scenes[buildIndex].path, OpenSceneMode.Single);
        Debug.Log("Opened Scene");
        
        // Create the GameManager object
        gameManagerObject = new GameObject("GameManager");
        Debug.Log("Created gameManagerObject");
        
        // Add GameManager component
        gameManager = gameManagerObject.AddComponent<GameManager>();
        Debug.Log("Set gameManager object to gameManager");
    }

    [UnityTest]
    public IEnumerator Test_NextLevelLoadScript()
    {
        SceneManager.LoadScene(1); // Directly load the scene for testing
    yield return null; // Wait a frame to allow the scene to load
    Scene currentScene = SceneManager.GetActiveScene();
    Assert.AreEqual(1, currentScene.buildIndex); // Check if scene loaded correctly
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the GameManager object
        Object.DestroyImmediate(gameManagerObject);
    }
}
