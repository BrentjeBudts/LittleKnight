using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] enemies;


    public Transform nextFloorPosition;
    public Transform leftSpawner;
    public Transform rightSpawner;
    public Transform playerSpawner;

    private GameObject enemy1;
    private GameObject enemy2;

    public bool isOnFloor;
    public bool isFinished;

    [SerializeField] private Collider2D border;
    
    private void Start()
    {
        enemy1  = Instantiate(enemies[0], rightSpawner.position, Quaternion.identity,transform);
        enemy1.GetComponentInChildren<OrkController>().moveRight = false;

        enemy2 = Instantiate(enemies[0], leftSpawner.position, Quaternion.identity,transform);
        enemy2.GetComponentInChildren<OrkController>().moveRight = true;
    }

    private void Update()
    {
        if (!enemy1 && !enemy2)
        {
            isFinished = true;
            isOnFloor = false;
            //Debug.Log("finished stage");
        }
    }
}
