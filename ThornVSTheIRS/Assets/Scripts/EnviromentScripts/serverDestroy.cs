using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serverDestroy : MonoBehaviour
{

    public AudioClip serverExplode;
    public Animator anim;
    BoxCollider2D triggerCollider;
    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GetComponent<AudioSource>();
        
        triggerCollider = GetComponent<BoxCollider2D>();
        triggerCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hit")
        {
            anim.SetBool("destroy", true);
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);

        }
    }

    public void crash()
    {
        GetComponent<AudioSource>().PlayOneShot(serverExplode);
    }

    public void explode()
    {

    }
}
