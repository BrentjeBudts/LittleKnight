using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject floorPrefab;

    [SerializeField] Transform startPoint;
    [SerializeField] private Player player;

    private List<GameObject> floors;
    private GameObject activeFloor;
    private GameObject previousFloor;
    private int floorIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        floors = new List<GameObject>();
        for (int i = 0; i <= 10; i++)
        {
            floorIndex = i;
            GameObject floor = Instantiate(floorPrefab, startPoint.position, Quaternion.identity);
            startPoint = floor.GetComponentInChildren<FloorManager>().transform;
            floor.name = "floor" + floorIndex;
            floors.Add(floor);
        }
        
        GetActiveFloor();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeFloor.GetComponentInChildren<FloorManager>().isFinished)
        {
            LoadNextFloor();
        }
    }

    void GetActiveFloor()
    {
        activeFloor = floors[0];
        player.activeFloor = activeFloor.GetComponentInChildren<FloorManager>();
        player.transform.position = activeFloor.GetComponentInChildren<FloorManager>().playerSpawner.position;
    }

    void LoadNextFloor()
    {
        Debug.Log("Loading next stage");
        PlayerClimbsUp();
        InitiateNewFloor();
    }

    void InitiateNewFloor()
    {
        floorIndex++;
        GameObject floor = Instantiate(floorPrefab, startPoint.position, Quaternion.identity);
        startPoint = floor.GetComponentInChildren<FloorManager>().transform;
        floor.name = "floor" + floorIndex;
        floors.Add(floor);
        Destroy(previousFloor);
    }

    void PlayerClimbsUp()
    {
        previousFloor = activeFloor;
        player.activeFloor.isOnFloor = false;
        floors.Remove(floors[0]);
        GetActiveFloor();
    }
}
