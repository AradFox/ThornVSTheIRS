using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    

    private Animator anim;
    public AudioClip grunt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Hit"))
        {
            Debug.Log("Kicked");
            GetComponent<AudioSource>().PlayOneShot(grunt);
            anim.SetBool("Death", true);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }



}
