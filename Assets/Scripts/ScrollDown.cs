using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    public bool scroll;
    public List<GameObject> floors= new List<GameObject>();
    public Vector3 previousStartpoint;

    private GameManager gameManager;

    private void Start()
    {
         gameManager = gameObject.GetComponentInChildren<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (scroll)
        {
            ShiftGame();
        }
    }

    void  ShiftGame()
    {
        Vector3 goToPoint = previousStartpoint;
        foreach (GameObject floor in floors)
        {
            floor.transform.position = goToPoint;
            goToPoint = floor.GetComponent<FloorManager>().nextFloorPosition.position;
        }
        gameManager.SetNewFloor();
    }
}
