using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bagStyl
{
    weapon,
    healthPotion
}

public class Bag : MonoBehaviour
{
    [System.Obsolete]
    public item[] items;
    Dictionary<int, item> itemDic;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //gain weapon
    public void getWeapon(bagStyl itemsGet)
    { 
        
    }

    //use items in bag
    public void useItem(int id)
    {

    }
    

}
[System.Serializable]
public class item
{
    public int id;
    public bagStyl bagStyl;
    public float hp;
    public float atk;
    public float mp;
}
