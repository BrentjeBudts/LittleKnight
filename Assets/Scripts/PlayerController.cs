using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool facingRight = false;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private Transform spawnPoint;

    public Animator animator;

    //TODO flip feels weird change with new sprite;
    
    public void TurnLeft()
    {
        if (facingRight)
        {
            facingRight = false;
            player.flipX = false;
        }
    }

    public void TurnRight()
    {
        if (!facingRight)
        {
            facingRight = true;
            player.flipX = true;
        }
    }

    public void Attack()
    {
        
        //TODO fix spawnposition
        Vector3 pos = spawnPoint.position;
        GameObject strike = Instantiate(bulletPrefab, new Vector3(pos.x, pos.y, pos.z) , Quaternion.identity, player.gameObject.transform.parent);
        
        strike.GetComponentInChildren<Strike>().player = player;
        animator.SetTrigger("Strike");
    }

    public void ClearStrikes()
    {
        
    }
}
