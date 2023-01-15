using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public FloorManager activeFloor;
    

    // Update is called once per frame
    void Update()
    {
        if (activeFloor)
        {
            activeFloor.isOnFloor = true;
        }
    }
}
