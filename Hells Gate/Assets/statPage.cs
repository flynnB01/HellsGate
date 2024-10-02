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
    public bool gamePaused;
    public HealthBar healthBar;
    public EnergyBar energyBar;



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

    
    
    TextMeshProUGUI newHealth_text;
    TextMeshProUGUI newEnergy_text;
    

    // Start is called before the first frame update
    void Start()
    {
        StatPage.SetActive(false);

        currentLevel_text = currentLevel.GetComponent<TextMeshProUGUI>();
        skillPoints_text = skillPoints.GetComponent<TextMeshProUGUI>();

        health_text = health.GetComponent<TextMeshProUGUI>();
        energy_text = energy.GetComponent<TextMeshProUGUI>();


        newHealth_text = newHealth.GetComponent<TextMeshProUGUI>();
        newEnergy_text = newEnergy.GetComponent<TextMeshProUGUI>();
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

        currentLevel_text.text = player.currentLv.ToString();
        skillPoints_text.text = player.skillPoints.ToString();

        health_text.text = player.maxHp.ToString();
        energy_text.text = player.maxEn.ToString();


        newHealth_text.text = (player.maxHp + 10).ToString();
        newEnergy_text.text = (player.maxEn + 10).ToString();
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
}
