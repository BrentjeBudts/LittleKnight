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

    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        canAttack = transform.parent.GetComponentInChildren<FloorManager>().isOnFloor;
        
        if (!hasCollided && canAttack )
        {
            if (moveRight)
            {
                transform.position += Vector3.right * (moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.name.Equals("Knight")) return;
        hasCollided = true;
    }

    void Attack()
    {
        //TODO animation -> on Animation ended do damage
    }
}
