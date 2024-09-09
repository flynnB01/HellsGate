using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    // initialize player lvl stats, ( can be given value in unity )
    [SerializeField] public int currentHp, maxHp, currentExp, maxExp, currentLv;
    public bool isDead = false; // checks if player is dead

    public HealthBar healthBar;

    void Start()
    {
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }

    private void OnEnable()
    {
        expManager.Instance.OnExpChange += HandleExpChange;
    }
    
    private void OnDisable()
    { 
        expManager.Instance.OnExpChange -= HandleExpChange;
    }

    private void HandleExpChange(int newExp)
    {
        currentExp += newExp;
        if (currentExp >= maxExp) // once current exp reaches level milestone
        {
            // TODO - update ui
            LevelUp();
        }
    }

    private void LevelUp()
    {
        // TODO - level up other stats (STR, DEF etc)
        currentLv += 1; // lvl up

        maxHp += 20; // increases characters maximum health points
        currentHp = maxHp; // regains hp after levelling up

        currentExp = 0; // resets current exp

        maxExp += 100; // sets new exp milestone
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        */
    }
    public void TakeDamage(int damage) // deals damage to player, argument is how much damage is dealt
    {
        currentHp -= damage;
        healthBar.SetHealth(currentHp);

        if (currentHp <= 0 && !isDead) // kills player
        {
            isDead = true;
            // Destroy(gameObject);
        }

        else if (currentHp > 0) 
        {
            isDead = false;
        }
    }

        
}

