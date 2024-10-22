using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class BossTest
{
    private GameObject boss; // boss object

    [Test]
    public void Test_DamageBoss()
    {
        boss = new GameObject();

        boss.AddComponent<Boss>();
        boss.GetComponent<Boss>().hp = 100; // set boss health
        boss.GetComponent<Boss>().takeDmg(25); // deal damage method

        int expected = 75; // health after damage dealt

        Assert.AreEqual(expected, boss.GetComponent<Boss>().hp);
    }

}
