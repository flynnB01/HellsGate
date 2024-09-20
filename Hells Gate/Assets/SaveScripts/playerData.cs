using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
    //stores player data to read to and from the save file
    public int sceneID;
    public int currentHp;
    public int currentExp;
    public int currentLv;
    public float[] position;
    
    public playerData(character player){
        sceneID = player.sceneID;
        currentHp = player.currentHp;
        currentExp = player.currentExp;
        currentLv = player.currentLv;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
