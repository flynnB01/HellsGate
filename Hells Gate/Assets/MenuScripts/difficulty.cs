using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class difficulty : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    public bool isEasy;
    public bool isNormal;
    public bool isHard;

    public void getDropdownValue(){
        int difficultyIndex = dropdown.value;

        if(difficultyIndex == 0){
            isEasy = false;
            isNormal = true;
            isHard = false;
        }else if(difficultyIndex == 1){
            isEasy = true;
            isNormal = false;
            isHard = false;
        }else if(difficultyIndex == 2){
            isEasy = false;
            isNormal = false;
            isHard = true;
        }
    }
}
