using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool facingRight = true;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnPoint;

    
    //TODO flip feels weird change with new sprite;
    
    public void TurnLeft()
    {
        if (facingRight)
        {
            facingRight = false;
            player.transform.localScale = new Vector3(-1,1,1);
        }
    }

    public void TurnRight()
    {
        if (!facingRight)
        {
            facingRight = true;
            player.transform.localScale = new Vector3(1,1,1);
        }
    }

    public void Attack()
    {
        Vector3 pos = spawnPoint.position;
        GameObject strike = Instantiate(bulletPrefab, new Vector3(pos.x, pos.y, pos.z) , Quaternion.identity, player);
        
        //Changing parent so that it doesnt flip with the player
        strike.transform.parent = player.parent;
        strike.GetComponentInChildren<Strike>().player = player;
    }
}
