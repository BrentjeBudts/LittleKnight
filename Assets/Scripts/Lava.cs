using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    public float moveSpeed;
    

    // Update is called once per frame
    private void Update()
    {
        var position = transform.position;
        position = new Vector3(position.x, position.y + moveSpeed);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.name.Equals("Knight")) return;
        moveSpeed = 0;
        Debug.Log("You burned to death");
    }
}
