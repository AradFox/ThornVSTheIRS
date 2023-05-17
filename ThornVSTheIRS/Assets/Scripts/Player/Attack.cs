using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Attack : MonoBehaviour
{

    private float attackTime;
    public float attackTimeStart;

    public Transform attackPos;
    public LayerMask attackMask;
    public float attackRange;
    public int damage;
    public Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
                playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, attackMask);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().takeDamage(damage);
                }
            }

            attackTime = attackTimeStart;
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
