using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezePositionY : MonoBehaviour
{

    Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;

        }
    }
}
