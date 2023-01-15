using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject floorPrefab;

    [SerializeField] Transform startPoint;
    [SerializeField] private GameObject player;

    private List<GameObject> floors;
    private GameObject activeFloor;
    
    

    // Start is called before the first frame update
    void Start()
    {
        floors = new List<GameObject>();
        for (int i = 0; i <= 10; i++)
        {
            GameObject floor = Instantiate(floorPrefab, startPoint.position, Quaternion.identity);
            startPoint = floor.GetComponentInChildren<FloorManager>().transform;
            floors.Add(floor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetActiveFloor();
        if (activeFloor)
        {
            if (activeFloor.GetComponentInChildren<FloorManager>().isFinished)
            {
                LoadNextFloor();
            }
        }
    }

    void GetActiveFloor()
    {
        foreach (GameObject go in floors)
        {
            if (go.GetComponentInChildren<FloorManager>().isOnFloor)
            {
                activeFloor = go;
                Debug.Log("found");
            }
        }
    }

    void LoadNextFloor()
    {
        Debug.Log("Loading next stage");
        PlayerClimbsUp();
        InitiateNewFloor();
        
    }

    void InitiateNewFloor()
    {
        
    }

    void PlayerClimbsUp()
    {
        
    }
    
}
