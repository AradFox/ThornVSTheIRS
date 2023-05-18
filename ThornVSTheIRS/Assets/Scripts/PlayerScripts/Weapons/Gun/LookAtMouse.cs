using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LookAtMouse : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    SpriteRenderer playerSpriteRenderer;

    // Use this for initialization
    void Start()
    {
        playerSpriteRenderer = GameObject.Find("Player (1)").GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //to set flipped gun back to normal
        if (playerSpriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;

            transform.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);

        }
        else if (!playerSpriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }
    }
}
