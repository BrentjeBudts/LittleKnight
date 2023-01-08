using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool facingRight = false;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform player;

    
    public void TurnLeft()
    {
        if (facingRight)
        {
            facingRight = false;
            player.transform.localScale = new Vector3(1,1,1);
        }
    }

    public void TurnRight()
    {
        if (!facingRight)
        {
            facingRight = true;
            player.transform.localScale = new Vector3(-1,1,1);
        }
    }

    public void Attack()
    {
        GameObject strike = Instantiate(bulletPrefab, player.position, Quaternion.identity);
        strike.GetComponentInChildren<Strike>().player = player;
    }
}
