using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{

    [SerializeField]
    GameObject electricExplosion;
    [SerializeField]
    GameObject hitCheck;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Hit"))
        {
            Instantiate(electricExplosion, transform.position, electricExplosion.transform.rotation);
            Destroy(hitCheck);

        }
       
    }
}
