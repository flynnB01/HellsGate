using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class Test1
{

    // A Test behaves as an ordinary method
    [Test]
    public void Test_BossAtkIsDefault()
    {
        Boss boss = new(); // make new BossAttack instance

        bool expected = false; // isAttacking should be false

        // Use the Assert class to test conditions
        Assert.AreEqual(expected, boss.isAttacking);

    }
}
