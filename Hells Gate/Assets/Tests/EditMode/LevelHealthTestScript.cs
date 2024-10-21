using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Character
{
    public int maxHp;
    
    public Character()
    {
        // Initializing the character's max HP
        
        maxHp = 100;
    }

    public void incremenntHp()
    {
        maxHp += 10;
    }
}

public class levelHealthTestScript
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
