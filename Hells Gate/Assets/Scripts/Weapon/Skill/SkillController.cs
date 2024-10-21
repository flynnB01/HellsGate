using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Manager all skills 
[System.Serializable]

public class Skill
{
    public float mana;
    public float damage;
    public float cooldown;
    public SkillParent skillPerformance;
}
public class SkillController : MonoBehaviour
{
    public Transform initialPoint;//where skills starts
    public SkillParent[] skills;//skills lists
    public float[] cooldown;//skills cd lists
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //skill1:  shoot something and dealt damage
        if (Input.GetKeyDown(KeyCode.Alpha1))//press 1
        {
            if (cooldown[0]<=0)//check in cd or not
            {
            GameObject skill=GameObject.Instantiate(skills[0].gameObject, initialPoint);//skill start
            skill.transform.localPosition = Vector3.zero;
            skills[0].Skill();//which skill in skill lists
            cooldown[0] = skills[0].cd;
               StartCoroutine(waitCoolDown(0, skills[0].cd));
            }
        }
        
    }

    IEnumerator waitCoolDown(int id,float cd)//cd system
    {
    
        while (cooldown[id] >= 0)//shows cd 
        {
            yield return new WaitForSeconds(0.1f);
            cooldown[id] -= 0.1f;
        };
        
    }
}
