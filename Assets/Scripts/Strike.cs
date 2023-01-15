using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    private bool hasHit = false;
    public float speed;
    public Transform player;
    private float direction;

    private void Start()
    {
        direction = player.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(direction,0) * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Strike Collision");
        Destroy(collision.transform.parent.gameObject);
        Destroy(gameObject);
    }
}
