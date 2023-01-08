using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] enemies;

    public GameObject leftSpawner;
    public GameObject rightSpawner;

    public bool isOnFloor;

    private void Start()
    {
        Debug.Log("start in floor");
        Instantiate(enemies[0], rightSpawner.transform.position, Quaternion.identity,transform.parent);
    }
}
