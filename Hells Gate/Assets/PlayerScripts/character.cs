using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    // initialize player lvl stats, ( can be given value in unity )
    [SerializeField] public int currentHp, maxHp, currentExp, maxExp, currentLv, currentEn, MaxEn;
    public bool isDead = false; // checks if player is dead
    public float energyRegenRate = 1f;
    public bool canRegen = true;
    public float regenCooldown = 5f;
    public bool startRegenCooldown = false;
    private bool isRegeneratingEnergy = false;

    public HealthBar healthBar; // Energy Bar health object
    public EnergyBar energyBar; // Energy Bar slider object

    public ExpBar expBar; // Energy Bar slider object
    public GameManager gameManager;
    public int sceneID;

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

        MaxEn += 50; // increase character energy points
        currentEn = MaxEn; // regain energy after level up


        currentExp = 0; // resets current exp

        maxExp += 100; // sets new exp milestone
        expBar.IncreaseMaxExp(100);
        healthBar.IncreaseMaxHealth(maxHp);
        energyBar.IncreaseMaxEnergy(MaxEn);
    }

    void Update()
    {
        //health bar level is checked on update instead of in take damage to can be set to proper level after loading game
        healthBar.SetHealth(currentHp);
        energyBar.SetEnergy(currentEn);

        sceneID = SceneManager.GetActiveScene().buildIndex;
        expBar.SetExp(currentExp);
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        */

        if (Input.GetKeyDown(KeyCode.E) && currentEn >= 20)
        {
            ReceiveHealth(20);
            Debug.Log("Healed Player");
            currentEn -= 20;
            canRegen = false;
            startRegenCooldown = true;
            StartCoroutine(EnergyRegenCooldown());
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            HandleExpChange(20); // Temporary
            Debug.Log("Gained XP"); // Temporary
            
        }

        if (Input.GetKeyDown(KeyCode.E) && currentEn < 20)
        {
            Debug.Log("Not enough energy");
        }

        // Check if the cooldown is active and if energy regeneration is needed
    if (!startRegenCooldown && currentEn < MaxEn && !isRegeneratingEnergy)
    {
        StartCoroutine(StartRegeneratingEnergy());
    }

    }
    public void TakeDamage(int damage) // deals damage to player, argument is how much damage is dealt
    {
        currentHp -= damage;
        if (currentHp <= 0 && !isDead) // kills player
        {
            
            isDead = true;
            gameManager.gameOver(); // Brings up Gameover UI
            // Destroy(gameObject);
        }

        else if (currentHp > 0)
        {
            isDead = false;
        }
    }

    public void ReceiveHealth(int healAmount) // For healing scripts
    {
        currentHp += healAmount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }

IEnumerator EnergyRegenCooldown()
{
    startRegenCooldown = true; // Activate cooldown flag
    yield return new WaitForSeconds(regenCooldown); // Wait for the cooldown period
    startRegenCooldown = false; // Reset the cooldown flag
}

IEnumerator StartRegeneratingEnergy()
{
    isRegeneratingEnergy = true; // Set the flag to true to prevent re-entry
    while (currentEn < MaxEn)
    {
        currentEn += 1; // Increment energy
        yield return new WaitForSeconds(energyRegenRate); // Wait for the defined regeneration rate
    }
    currentEn = MaxEn; // Ensure we cap it at MaxEn
    isRegeneratingEnergy = false; // Set the flag to true to prevent re-entry
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

        SceneManager.LoadScene(sceneID);

        currentHp = data.currentHp;
        currentExp = data.currentExp;
        currentLv = data.currentLv;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    //called if player chooses to reload from last save after dying
    public void Respawn()
    {
        isDead = false;
        Time.timeScale = 1;

        //loads player data
        playerData data = SaveSystem.LoadPlayer();

        SceneManager.LoadScene(data.sceneID);

        currentHp = data.currentHp;
        currentExp = data.currentExp;
        currentLv = data.currentLv;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    //saves game when player collides with a object with the tag 'respawn'/ a checkpoint
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Respawn"))
        {
            SavePlayer();
            Debug.Log("Game saved at checkpoint");
        }

        if (collider.gameObject.CompareTag("DeathBox"))
        {
            TakeDamage(99999);
            Debug.Log("Player fell out of world");
        }
    }
}