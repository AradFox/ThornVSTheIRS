using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour
{

    public TextMeshProUGUI bossText;
    public Slider bossSlider;
    public AudioClip walksound;

    Rigidbody2D rb;
    Animator anim;

    public Transform player;
    public bool triggered = false;
    public float moveSpeed;

    public bool dead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
            moveSpeed = 2.5f;
        
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {

            if  (dead == false)
            {

                

                if (triggered == true)
                {


                    Vector2 moveDir = player.position - transform.position;
                    moveDir.Normalize();
                    rb.velocity = moveDir * moveSpeed;
                    if (moveDir.x >= 0)
                    {
                        Vector3 scale = transform.localScale;
                        scale.x = -3;
                        transform.localScale = scale;

                    }
                    else
                    {
                        Vector3 scale = transform.localScale;
                        scale.x = 3;
                        transform.localScale = scale;

                    }

                    anim.SetFloat("XMove", moveDir.x);
                }
            }
        }


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Hit"))
        {
            dead = true;
            Debug.Log("killed");
            triggered = false;
        }
    }

    public void walking()
    {
        GetComponent<AudioSource>().PlayOneShot(walksound);
    }

   
}
