using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    // initialize player lvl stats, ( can be given value in unity )
    [SerializeField] public int currentHp, maxHp, currentExp, maxExp, currentLv;
    public bool isDead = false; // checks if player is dead

    public HealthBar healthBar;

    void Start()
    {
        //case '2' is active so game loads with saved data
        if (MainMenu.loadSavedGame == 2)
        {
            playerData data = SaveSystem.LoadPlayer();

            if (data != null)
            {
                currentHp = data.currentHp;
                currentExp = data.currentExp;
                currentLv = data.currentLv;

                Vector3 position;
                position.x = data.position[0];
                position.y = data.position[1];
                position.z = data.position[2];
                transform.position = position;

                Debug.LogError("Game loaded successfully.");
            }
            else
            {
                Debug.LogError("No save file found.");
            }
        }
        //case '3' is active so game loads and scene is immediatly reset
        else if(MainMenu.loadSavedGame == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            MainMenu.loadSavedGame = 1;
        }
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
        //health bar level is checked on update instead of in take damage to can be set to proper level after loading game
        healthBar.SetHealth(currentHp);
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

    public void SavePlayer()
    {
        //saves player data
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        //loads player data
        playerData data = SaveSystem.LoadPlayer();

        currentHp = data.currentHp;
        currentExp = data.currentExp;
        currentLv = data.currentLv;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}