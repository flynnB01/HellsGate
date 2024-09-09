using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // init enemy stats
    public int expValue;

    void Death() // when enemy dies
    {
        expManager.Instance.AddExp(expValue);
    }
}
