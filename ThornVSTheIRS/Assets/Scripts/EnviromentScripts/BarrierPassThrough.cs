using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPassThrough : MonoBehaviour
{
    
    
    public BoxCollider2D bc;
    
    // Start is called before the first frame update
    void Start()
    {
       
        

        bc =  GetComponentInParent<BoxCollider2D>();
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hit")
        {
           bc.enabled = false;
           
        }
        else
        {
            bc.enabled = true;
        }
    }
}
