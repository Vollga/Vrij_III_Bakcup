﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRunner : MonoBehaviour
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

    bool[,] mapArray;
    List<GameObject> roomsList;



    // Start is called before the first frame update
    void Start()
    {
        roomsList = new List<GameObject>();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach( GameObject room in roomsList)
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
        // Initialising map grid array
        mapArray = new bool[gridsize, gridsize + 1];

        // Start runnin'
        if(runnersKnowDirection == true)
        {
            for (int i = 0; i < runners; i++)
            {
                RunnerSteering(new Vector2(gridsize / 2, gridsize / 2), Random.Range(5, maxDistance+1),Random.Range(0,4));
            }
        }
        else
        {
            for (int i = 0; i < runners; i++)
            {
                RunnerRandom(new Vector2(gridsize / 2, gridsize / 2), Random.Range(5, maxDistance+1));
            }
        }
        

        // Place Placeholders
        DrawMap();

        //Generating Start Room
        //Instantiate(tile, new Vector3(gridsizeX / 2, 0, gridsizeZ / 2), Quaternion.identity);
    }

    void RunnerRandom(Vector2 runnerPosCurrent, int runnerDistance) //Runner with random direction, can go back on itself
    {
        // Set given position as true
        mapArray[(int) runnerPosCurrent.x, (int) runnerPosCurrent.y] = true;
        print("Map Array Entry " + (int)runnerPosCurrent.x + "," + (int)runnerPosCurrent.y + " has been set to: " + mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y]);

        // Decide direction for next instance, Advance on grid
        Vector2 runnerPosNext = runnerPosCurrent;
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0: //up
                runnerPosNext.y++;
                print("Next Direction: Up");
                break;

            case 1: //right
                runnerPosNext.x++;
                print("Next Direction: Right");
                break;

            case 2: //down
                runnerPosNext.y--;
                print("Next Direction: Down");
                break;

            case 3: //left
                runnerPosNext.x--;
                print("Next Direction: Left");
                break;

        }

        // Start next runner if not at goal
        if((runnerDistance-1 > 0))
        {
            if((runnerPosNext.x >= gridsize) | (runnerPosNext.y >= gridsize) | (runnerPosNext.x < 0) | (runnerPosNext.y < 0))
            {
                print("Whoops! Out of bounds");
            }
            else
            {
                print((runnerDistance - 1) + " steps to go");
                RunnerRandom(runnerPosNext, runnerDistance - 1);
            }
        }
    }

    void RunnerSteering(Vector2 runnerPosCurrent, int runnerDistance, int previousDirection) //Runner that can't go back on itself
    {
        // Set given position as true
        mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y] = true;
        print("Map Array Entry " + (int)runnerPosCurrent.x + "," + (int)runnerPosCurrent.y + " has been set to: " + mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y]);

        // Decide direction for next instance, Advance on grid
        Vector2 runnerPosNext = runnerPosCurrent;

        int newDirection = Random.Range(0, 4);
        while(newDirection == previousDirection)
        {
            newDirection = Random.Range(0, 4);
        }

        switch (newDirection)
        {
            case 0: //up
                runnerPosNext.y++;
                print("Next Direction: Up");
                break;

            case 1: //right
                runnerPosNext.x++;
                print("Next Direction: Right");
                break;

            case 2: //down
                runnerPosNext.y--;
                print("Next Direction: Down");
                break;

            case 3: //left
                runnerPosNext.x--;
                print("Next Direction: Left");
                break;

        }

        // Start next runner if not at goal
        if ((runnerDistance - 1 > 0))
        {
            if ((runnerPosNext.x >= gridsize) | (runnerPosNext.y >= gridsize) | (runnerPosNext.x < 0) | (runnerPosNext.y < 0))
            {
                print("Whoops! Out of bounds");
            }
            else
            {
                print((runnerDistance - 1) + " steps to go");
                RunnerSteering(runnerPosNext, runnerDistance - 1, newDirection);
            }
        }
    }

    void DrawMap()
    {
        for(int iZ = 0; iZ < gridsize; iZ++)
        {
            for (int iX = 0; iX < gridsize; iX++)
            {
                if (mapArray[iX,iZ] == true)
                {
                    roomsList.Add( Instantiate(tile, new Vector3(iX-(gridsize/2),0,iZ-(gridsize/2)), Quaternion.identity));
                }
            }
        }
    }
}