using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class statPage : MonoBehaviour
{
    [SerializeField] GameObject StatPage;
    public GameManager gameManager;
    public GameObject pauseMenuUI;
    public character player;
    public playerMovement pm;
    public bool gamePaused;
    public HealthBar healthBar;
    public EnergyBar energyBar;
    public PlayerAttack playerAttack;


    public GameObject currentLevel;
    public GameObject skillPoints;
    public GameObject health;
    public GameObject energy;
    public GameObject strength;
    public GameObject agility;
    public GameObject luck;
    public GameObject newHealth;
    public GameObject newEnergy;
    public GameObject newStrength;
    public GameObject newAgility;
    public GameObject newLuck;


    TextMeshProUGUI currentLevel_text;
    TextMeshProUGUI skillPoints_text;
    TextMeshProUGUI health_text;
    TextMeshProUGUI energy_text;
    TextMeshProUGUI strength_text;
    TextMeshProUGUI agility_text;
    TextMeshProUGUI luck_text;

    
    TextMeshProUGUI newHealth_text;
    TextMeshProUGUI newEnergy_text;
    TextMeshProUGUI newStrength_text;
    TextMeshProUGUI newAgility_text;
    TextMeshProUGUI newLuck_text;
    

    // Start is called before the first frame update
    void Start()
    {
        StatPage.SetActive(false);

        currentLevel_text = currentLevel.GetComponent<TextMeshProUGUI>();
        skillPoints_text = skillPoints.GetComponent<TextMeshProUGUI>();

        health_text = health.GetComponent<TextMeshProUGUI>();
        energy_text = energy.GetComponent<TextMeshProUGUI>();
        strength_text = strength.GetComponent<TextMeshProUGUI>();
        agility_text = agility.GetComponent<TextMeshProUGUI>();
        luck_text = luck.GetComponent<TextMeshProUGUI>();

        newHealth_text = newHealth.GetComponent<TextMeshProUGUI>();
        newEnergy_text = newEnergy.GetComponent<TextMeshProUGUI>();
        newStrength_text = newStrength.GetComponent<TextMeshProUGUI>();
        newAgility_text = newAgility.GetComponent<TextMeshProUGUI>();
        newLuck_text = newLuck.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gamePaused == false && pauseMenuUI.activeSelf == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            gameManager.statPageActive();
        }
        else if (Input.GetKeyDown(KeyCode.E) && gamePaused == true && pauseMenuUI.activeSelf == false)
        {
            Time.timeScale = 1;
            gamePaused = false;
            StatPage.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == true && pauseMenuUI.activeSelf == false)
        {
            Time.timeScale = 1;
            gamePaused = false;
            StatPage.SetActive(false);
        }

        currentLevel_text.text = player.currentLv.ToString();
        skillPoints_text.text = player.skillPoints.ToString();

        health_text.text = player.maxHp.ToString();
        energy_text.text = player.maxEn.ToString();
        strength_text.text = player.strength.ToString();
        agility_text.text = (pm.moveSpeed).ToString();
        luck_text.text = player.luck.ToString();

        newHealth_text.text = (player.maxHp + 10).ToString();
        newEnergy_text.text = (player.maxEn + 10).ToString();
        newStrength_text.text = (player.strength + 1).ToString();
        newAgility_text.text = (pm.moveSpeed + 1).ToString();
        newLuck_text.text = (player.luck + 1).ToString();
    }

    public void UpgradeHealth(){
        if(player.skillPoints > 0){
            player.maxHp += 10;
            player.skillPoints--;
            healthBar.IncreaseMaxHealth(player.maxHp);
        }
    }

    public void UpgradeEnergy(){
        if(player.skillPoints > 0){
            player.maxEn += 10;
            player.skillPoints--;
            energyBar.IncreaseMaxEnergy(player.maxEn);
        }
    }

    public void UpgradeStrength(){
        if(player.skillPoints > 0){
            player.strength++;
            player.skillPoints--;
        }
    }

    public void UpgradeAgility(){
        if(player.skillPoints > 0){
            pm.moveSpeed += 1;
            pm.jumpSpeed += 1;
            player.skillPoints--;
        }
    }

    public void UpgradeLuck(){
        if(player.skillPoints > 0){
            player.luck++;
            player.skillPoints--;
        }
    }
}
