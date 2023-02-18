using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkController : MonoBehaviour
{

    private bool hasCollided;

    public int moveSpeed;
    public bool canAttack;
    public bool moveRight;
    public Collider2D borderCollider;

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
            if (moveRight)
            {
                transform.parent.position += Vector3.right * (moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.parent.position += Vector3.left * (moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
   
        if (col.collider == borderCollider)
        {
            Debug.Log("BORDER");
            hasCollided = true;
            Attack();
        }
    }

    void Attack()
    {
        //TODO animation -> on Animation ended do damage
    }
}
