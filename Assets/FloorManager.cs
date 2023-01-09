using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] enemies;

    public GameObject leftSpawner;
    public GameObject rightSpawner;

    public GameObject enemy1;
    public GameObject enemy2;

    public bool isOnFloor;

    private void Start()
    {
        enemy1  = Instantiate(enemies[0], rightSpawner.transform.position, Quaternion.identity,transform.parent);
        enemy1.GetComponentInChildren<OrkController>().moveRight = false;
        enemy2 = Instantiate(enemies[0], leftSpawner.transform.position, Quaternion.identity,transform.parent);
        enemy2.GetComponentInChildren<OrkController>().moveRight = true;
    }

    private void Update()
    {
        if (!enemy1 && !enemy2)
        {
            Debug.Log("finished stage");
        }
    }
}
