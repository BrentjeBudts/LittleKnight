using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    public bool scroll;
    public List<GameObject> floors;
    public Vector2 previousStartpoint;

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
            Vector2 goToPoint = previousStartpoint;
            foreach (GameObject floor in floors)
            {
                floor.transform.position = Vector2.MoveTowards(floor.transform.position,goToPoint,5f * Time.deltaTime);
                
                if (Vector2.Distance(goToPoint,floor.transform.position)<0.001f)
                {
                    scroll = false;
                    
                    gameManager.SetNewFloor();
                }
            }
        }
    }
}
