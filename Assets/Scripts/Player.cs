using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private FloorManager activeFloor;
    

    // Update is called once per frame
    void Update()
    {
        if (activeFloor)
        {
            activeFloor.isOnFloor = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("stom wijf houd u bakkes");
        activeFloor = col.gameObject.GetComponentInChildren<FloorManager>();
    }
}
