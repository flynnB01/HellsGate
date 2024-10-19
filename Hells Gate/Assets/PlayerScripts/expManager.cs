using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expManager : MonoBehaviour
{
    public static expManager Instance;

    public delegate void ExpChangeHandler(int amt);
    public event ExpChangeHandler OnExpChange;

    private void Awake()
    {
        if (Instance != null && Instance != this) { // makes sure one exp manager is active at a time
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public void AddExp(int amt) {
        OnExpChange?.Invoke(amt);
    }
}
