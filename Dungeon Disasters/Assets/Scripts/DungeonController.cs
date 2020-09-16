using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    // Public variables
    [Header("Map Setup")]
    public GameObject tile;
    [Range(5, 30)]
    public int gridsize;

    [Header("Runner Parameters")]
    [Range(1, 10)]
    public int runners;
    [Range(5, 100)]
    public int maxDistance;
    public bool runnersKnowDirection;
    
    // Dungeon Storage
    bool[,] mapArray;
    List<GameObject> roomsList;


    // Start is called before the first frame update
    void Start()
    {
        roomsList = new List<GameObject>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (GameObject room in roomsList)
            {
                Destroy(room);
            }
            roomsList.Clear();
            InitialiseDungeon();
            print("This dungeon has " + roomsList.Count + " rooms.");
        }
    }
}
