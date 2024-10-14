using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BoxCollider2D box;
    public character player;
    private int strength;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //when play attack, turn attackbox on
    public void AtkStar()
    {
        box.enabled = true;
    }

    //close attackbox when attack is over
    public void AtkOver()
    {
        box.enabled = false;
    }

    public void hitsEnemey(Collider2D collision)//if attack box detect enemy, dealt dmg
    {
        collision.GetComponent<enemy>().takeDmg(player.strength);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<enemy>().takeDmg(player.strength);
    }
}
