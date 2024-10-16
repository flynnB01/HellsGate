using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
    //stores player data to read to and from the save file
    public int sceneID;
    public int currentHp;
    public int maxHp;
    public int currentEn;
    public int maxEn;
    public int currentExp;
    public int maxExp;
    public int currentLv;
    public int skillPoints;
    public float moveSpeed;
    public float jumpSpeed;
    public float[] position;
    
    public playerData(character player){
        sceneID = player.sceneID;
        currentHp = player.currentHp;
        maxHp = player.maxHp;
        currentEn = player.currentEn;
        maxEn = player.maxEn;
        currentExp = player.currentExp;
        maxExp = player.maxExp;
        currentLv = player.currentLv;
        skillPoints = player.skillPoints;
        moveSpeed = player.moveSpeed;
        jumpSpeed = player.jumpSpeed;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
