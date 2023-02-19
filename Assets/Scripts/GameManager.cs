using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameObject floorPrefab;

    [SerializeField] Transform nextFloorPosition;
    [SerializeField] private Player player;
    [SerializeField] private ScrollDown scroller;

    private List<GameObject> floors;
    public GameObject activeFloor;
    
    private int floorIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        floors = new List<GameObject>();
        for (int i = 0; i <= 10; i++)
        {
            floorIndex = i;
            GameObject floor = Instantiate(floorPrefab, nextFloorPosition.position, Quaternion.identity,transform.parent);
            nextFloorPosition = floor.GetComponent<FloorManager>().nextFloorPosition;
            floor.name = "floor" + floorIndex;
            floors.Add(floor);
        }
        SetNewFloor();
        player.transform.position = activeFloor.GetComponent<FloorManager>().playerSpawner.position;
        player.canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeFloor.GetComponent<FloorManager>().isFinished)
        {
            Debug.Log("Handling next stage");
            GameObject previousFloor = activeFloor;
            player.activeFloor.isOnFloor = false;
            player.ClearStrikes();
            scroller.previousStartpoint = new Vector2(floors[0].transform.position.x,floors[0].transform.position.y);
            floors.Remove(floors[0]);

            scroller.floors = floors;
            scroller.scroll = true;
            activeFloor = floors[0];
            InitiateNewFloor(previousFloor);
            
        }
    }

    public void SetNewFloor()
    {
        activeFloor = floors[0];
        player.activeFloor = activeFloor.GetComponent<FloorManager>();
        player.canAttack = true;
    }
    
    void InitiateNewFloor(GameObject toDestroy)
    {
        floorIndex++;
        GameObject floor = Instantiate(floorPrefab, nextFloorPosition.position, Quaternion.identity);
        nextFloorPosition = floor.GetComponent<FloorManager>().nextFloorPosition;
        floor.name = "floor" + floorIndex;
        floors.Add(floor);
        Debug.Log("Destroying floor " + toDestroy.name );
        Destroy(toDestroy);
    }
    
}
