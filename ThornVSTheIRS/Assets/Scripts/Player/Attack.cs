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
    }

    private void OnDrawGizmosSelected()
    {
    }
}
