using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    private bool hasHit = false;
    public float speed;
    public SpriteRenderer player;
    private float direction;

    private void Start()
    {
        direction = player.flipX ? 1 : -1;
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
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
