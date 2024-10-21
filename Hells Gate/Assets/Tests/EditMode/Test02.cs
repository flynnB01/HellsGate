using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class Test2
{
    [Test]
    public void Test_RecieveSkillPointScript()
    {
        character player = new();

        player.skillPoints = 0;

        player.levelUp();

        int expected = 3;

        Assert.AreEqual(expected, player.skillPoints);
    }
}
