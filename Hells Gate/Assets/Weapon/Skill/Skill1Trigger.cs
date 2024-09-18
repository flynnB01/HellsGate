using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//what will happen when the skills touch enemy
public class Skill1Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)//skill1 invoke parent skill
    {
        transform.parent.GetComponent<SkillParent>().skillCollision(collision);
    }
}
