using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject floorPrefab;

    [SerializeField] Transform startPoint ;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            GameObject floor = Instantiate(floorPrefab, startPoint.position, Quaternion.identity);
            startPoint = floor.GetComponentInChildren<FloorManager>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
