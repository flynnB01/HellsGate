using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // init enemy stats
    public int expValue;
    public int hp; //enemy hp


    public void dmgDealt()
    {
        
    }


    void Death() // when enemy dies
    {
        expManager.Instance.AddExp(expValue);
    }

    

}


