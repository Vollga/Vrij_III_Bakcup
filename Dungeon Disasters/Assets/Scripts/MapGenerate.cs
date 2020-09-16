using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerate : MonoBehaviour
{


    // Runner Variants
    
    public static Room[,] RunnerBasic(Room[,] dungeon, Vector2 runnerPosCurrent, int runnerDistance) //Runner with random direction, can go back on itself
    {
        // Set given position as true
        dungeon[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y].Enable();
        print("Map Array Entry " + (int)runnerPosCurrent.x + "," + (int)runnerPosCurrent.y + " has been set to: " + dungeon[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y]);

        Vector2 runnerPosNext = runnerPosCurrent;

        Vector2 newDirection = RandomDirVector();   // Get new direction

        runnerPosNext += newDirection;              // Set next runner's position in array

        // Start next runner if not at goal
        if ((runnerDistance - 1 > 0))
        {
            if ((runnerPosNext.x >= dungeon.GetLength(0) - 1) | (runnerPosNext.y >= dungeon.GetLength(1) - 1) | (runnerPosNext.x < 1) | (runnerPosNext.y < 1))
            {
                print("Whoops! Out of bounds");
            }
            else
            {
                print((runnerDistance - 1) + " steps to go");
                dungeon = RunnerBasic(dungeon, runnerPosNext, runnerDistance - 1);
            }
        }

        return dungeon;
    }
    
    public static Room[,] RunnerNoBacktrack(Room[,] dungeon, Vector2 runnerPosCurrent, int runnerDistance, Vector2 previousDirection) //Runner that can't go back on itself
    {
        // Set given position as true
        dungeon[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y].Enable();
        print("Map Array Entry " + (int)runnerPosCurrent.x + "," + (int)runnerPosCurrent.y + " has been set to: " + dungeon[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y]);

        Vector2 runnerPosNext = runnerPosCurrent;

        Vector2 newDirection = RandomDirVector(); // Get new direction

        while (newDirection == previousDirection) // Check if the new direction would be going back on itself
        {

            newDirection = RandomDirVector();
        }

        runnerPosNext += newDirection;           // Set next runner's position in array

        if ((runnerDistance - 1 > 0))           // Start next runner if not at goal
        {
            if ((runnerPosNext.x >= dungeon.GetLength(0) - 1) | (runnerPosNext.y >= dungeon.GetLength(1) - 1) | (runnerPosNext.x < 1) | (runnerPosNext.y < 1))
            {
                print("Whoops! Out of bounds");
            }
            else
            {
                print((runnerDistance - 1) + " steps to go");
                dungeon = RunnerNoBacktrack(dungeon, runnerPosNext, runnerDistance - 1, newDirection * -1);
            }
        }
        return dungeon;
    }

    public static Room[,] RunnerStraightAhead(Room[,] dungeon, Vector2 runnerPosCurrent, int runnerDistance, Vector2 previousDirection) //Runner that can't go back on itself, instead it defaults to going straight
    {
        // Set given position as true
        dungeon[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y].Enable();
        print("Map Array Entry " + (int)runnerPosCurrent.x + "," + (int)runnerPosCurrent.y + " has been set to: " + dungeon[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y]);

        // Decide direction for next instance, Advance on grid
        Vector2 runnerPosNext = runnerPosCurrent;


        Vector2 newDirection = RandomDirVector();

        if (newDirection == previousDirection)
        {

            newDirection = previousDirection * -1;
        }

        runnerPosNext += newDirection;

        // Start next runner if not at goal
        if ((runnerDistance - 1 > 0))
        {
            if ((runnerPosNext.x >= dungeon.GetLength(0) - 1) | (runnerPosNext.y >= dungeon.GetLength(1) - 1) | (runnerPosNext.x < 1) | (runnerPosNext.y < 1))
            {
                print("Whoops! Out of bounds");
            }
            else
            {
                print((runnerDistance - 1) + " steps to go");
                dungeon = RunnerStraightAhead(dungeon, runnerPosNext, runnerDistance - 1, newDirection * -1);
            }
        }

        return dungeon;
    }


    // Special Room Generators

    public static Room[,] PlaceStart(Room[,] dungeon)
    {
        for (int iZ = 0; iZ < dungeon.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < dungeon.GetLength(0); iX++)
            {

            }
        }




        return dungeon;
    }

    // Generate Room IDs

    public static Room[,] AssignRoom(Room[,] dungeon, DungeonDict roomSet)
    {
        for (int iZ = 0; iZ < dungeon.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < dungeon.GetLength(0); iX++)
            {
                dungeon[iX, iZ].roomAsset = roomSet.CornerUpRight[Random.Range(0,roomSet.CornerUpRight.Length)];
            }
        }
        return dungeon;
    }


    // Additional Functions

    public static Vector2 RandomDirVector() //Generate a random direction
    {
        Vector2 newDirection = new Vector2();
        int chooseDirection = Random.Range(0, 4);
        switch (chooseDirection)
        {
            case 0: //up
                newDirection = new Vector2(0, 1);
                print("Next Direction: Up");
                break;

            case 1: //right
                newDirection = new Vector2(1, 0);
                print("Next Direction: Right");
                break;

            case 2: //down
                newDirection = new Vector2(0, -1);
                print("Next Direction: Down");
                break;

            case 3: //left
                newDirection = new Vector2(-1, 0);
                print("Next Direction: Left");
                break;

        }

        return newDirection;
    }
}
