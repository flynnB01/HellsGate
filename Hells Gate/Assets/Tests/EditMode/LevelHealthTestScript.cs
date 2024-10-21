using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class LevelHealthTestScript
{
    [Test]
    public void Test_NextLevelLoadScript()
    {
        GameManager gameManager = new();
        

        gameManager.nextLevel = 2;

        gameManager.LoadNextLevel();

        Scene currentScene = SceneManager.GetActiveScene();

        int expected = 2;

        Assert.AreEqual(expected, currentScene);
    }
}
