using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class statPage : MonoBehaviour
{
    [SerializeField] GameObject StatPage;
    public GameManager gameManager;
    public GameObject pauseMenuUI;
    public bool gamePaused;


    public GameObject currentLevel;
    public GameObject skillPoints;
    public GameObject health;
    public GameObject energy;
    public GameObject strength;
    public GameObject agility;
    public GameObject luck;
    

    // Start is called before the first frame update
    void Start()
    {
        StatPage.SetActive(false);
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
    }
}
