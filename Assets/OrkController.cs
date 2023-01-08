using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkController : MonoBehaviour
{
    private int hp;

    private bool hasCollided;

    public int moveSpeed;
    public bool canAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        canAttack = transform.parent.parent.GetComponentInChildren<FloorManager>().isOnFloor;
        
        if (!hasCollided && canAttack )
        {
            transform.parent.position += Vector3.right * (moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("BL") || col.gameObject.name.Equals("BR"))
        {
            hasCollided = true;
            Attack();
        }
    }

    void Attack()
    {
        //TODO animation -> on Animation ended do damage
    }
}
