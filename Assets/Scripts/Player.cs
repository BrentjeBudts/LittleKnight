using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public FloorManager activeFloor;
    public bool canAttack;
    

    // Update is called once per frame
    void Update()
    {
        if (activeFloor)
        {
            activeFloor.isOnFloor = true;
        }
    }
    
    public void ClearStrikes()
    {
        foreach (Transform strikes in transform)
        {
            Destroy(strikes.gameObject);
        }
        canAttack = false;
    }
}
