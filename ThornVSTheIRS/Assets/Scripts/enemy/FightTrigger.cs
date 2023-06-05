using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTrigger : MonoBehaviour
{

    BossAI bossAI;
   public bool usingBossAI = true;
    public GameObject boss;
 
    BoxCollider2D triggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        bossAI = boss.GetComponent<BossAI>();
        triggerCollider = GetComponent<BoxCollider2D>();
        triggerCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TriggerFight();
        }
    }

    public void TriggerFight()
    {
        if (bossAI.dead == false)
        triggerCollider.enabled = false;
        if (usingBossAI)
        {
            bossAI.triggered = true;
        }
        Debug.Log("fight was triggered");
    }
}
