using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    // Public variables
    [Header("Map Setup")]
    public GameObject tile;
    public DungeonDict roomSet;
    [Range(5, 30)]
    public int gridsize;
    public bool drawEmptyRooms;
    public GameObject emptyTile;

    [Header("Runner Parameters")]
    [Range(1, 10)]
    public int runners;
    [Range(5, 100)]
    public int maxDistance;
    public bool runnersKnowDirection;

    // Dungeon Storage
    public Room[,] dungeon;
    List<GameObject> roomsList = new List<GameObject>();

    
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

    void InitialiseDungeon()
    {
        // Initialise dungeon layout
        dungeon = new Room[gridsize, gridsize];
        
        // Populate dungeon array
        for (int iZ = 0; iZ < dungeon.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < dungeon.GetLength(0); iX++)
            {
                dungeon[iX, iZ] = new Room();
            }
        }

        // Start runnin' and populate array with basic dungeon
        if (runnersKnowDirection == true)    // runner knows it's previous direction
        {
            for (int i = 0; i < runners; i++)
            {
               dungeon = MapGenerate.RunnerNoBacktrack(dungeon, new Vector2(gridsize / 2, gridsize / 2), Random.Range(5, maxDistance + 1), MapGenerate.RandomDirVector());
            }
        }
        else
        {
            for (int i = 0; i < runners; i++) // runner doesnt know it's previous direction
            {
                dungeon = MapGenerate.RunnerBasic(dungeon, new Vector2(gridsize / 2, gridsize / 2), Random.Range(5, maxDistance + 1));
            }
        }

        // Add extra Rooms to array
        MapGenerate.PlaceStart(dungeon);
        MapGenerate.PlaceSpecial(dungeon);


        // Assign Room Assets
        RoomFunctions.AssignRoomTypes(dungeon, roomSet);

        // Place Placeholders
        roomsList = DungeonSpawner.DrawLayout(dungeon, this.transform.position, this.transform, drawEmptyRooms, emptyTile);

        //Generating Start Room
        //Instantiate(tile, new Vector3(gridsizeX / 2, 0, gridsizeZ / 2), Quaternion.identity);
    }
}
