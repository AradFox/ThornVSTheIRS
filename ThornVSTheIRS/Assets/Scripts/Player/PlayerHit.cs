using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    [SerializeField]
    GameObject hitPicture;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("kickable"))
        {
            Instantiate(hitPicture,new Vector2 (transform.position.x +1f, transform.position.y), Quaternion.identity);
        }
    }
}
