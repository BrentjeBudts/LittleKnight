using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] enemies;

    public Transform leftSpawner;
    public Transform rightSpawner;
    public Transform playerSpawner;

    public GameObject enemy1;
    public GameObject enemy2;

    public bool isOnFloor;
    public bool isFinished;

    [SerializeField] private Collider2D border;
    
    private void Start()
    {
        enemy1  = Instantiate(enemies[0], rightSpawner.position, Quaternion.identity,transform.parent);
        enemy1.GetComponentInChildren<OrkController>().moveRight = false;
        enemy1.GetComponentInChildren<OrkController>().borderCollider = border;
        enemy2 = Instantiate(enemies[0], leftSpawner.position, Quaternion.identity,transform.parent);
        enemy2.GetComponentInChildren<OrkController>().moveRight = true;
        enemy2.GetComponentInChildren<OrkController>().borderCollider = border;
    }

    private void Update()
    {
        if (!enemy1 && !enemy2)
        {
            isFinished = true;
            isOnFloor = false;
            Debug.Log("finished stage");
        }
    }
}
