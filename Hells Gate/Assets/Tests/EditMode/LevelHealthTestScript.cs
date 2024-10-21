using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
    public void testLeveHealth()
    {
        // Create an instance of the character
        Character character = new Character();

        // Ensure the initial maxHp is as expected
        Assert.AreEqual(100, character.maxHp);

        // Simulate a level-up
        character.incremenntHp();

        // Check if the maxHp increased correctly after leveling up
        Assert.AreEqual(110, character.maxHp);
    }
}

