using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NextLevelLoadScript
{
    private GameObject gameManagerObject;
    private GameManager gameManager;

    [SetUp]
    public void Setup()
    {
        // Load a scene directly in Play Mode using SceneManager
        SceneManager.LoadScene(1); // Ensure this index is valid
        gameManagerObject = new GameObject("GameManager");
        gameManager = gameManagerObject.AddComponent<GameManager>();
    }

    [UnityTest]
    public IEnumerator Test_NextLevelLoadScript()
    {
        gameManager.nextLevel = 2;
        gameManager.LoadNextLevel();
        yield return new WaitUntil(() => SceneManager.GetActiveScene().buildIndex == 2);
        Scene currentScene = SceneManager.GetActiveScene();
        Assert.AreEqual(2, currentScene.buildIndex);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(gameManagerObject);
    }
}
