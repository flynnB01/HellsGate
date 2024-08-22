using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // TODO - enemy movement scripts, hp values etc
    int expValue = 20;

    void Death() // when enemy dies
    {
        expManager.Instance.AddExp(expValue);
    }
}
