using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    BossAI bossAI;
    public GameObject boss;
    public Animation open;
   public AudioClip openSound;
    // Start is called before the first frame update
    void Start()
    {
        bossAI = boss.GetComponent<BossAI>();
        open = GetComponent<Animation>();
        GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    
        
            
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hit")
        {
            open.Play();
            
        }
    }

    public void crash()
    {
        GetComponent<AudioSource>().PlayOneShot(openSound);
    }
}
