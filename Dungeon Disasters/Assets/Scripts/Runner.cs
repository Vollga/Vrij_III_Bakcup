using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void RunnerRandom(Vector2 runnerPosCurrent, int runnerDistance) //Runner with random direction, can go back on itself
    {
        // Set given position as true
        mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y] = true;
        print("Map Array Entry " + (int)runnerPosCurrent.x + "," + (int)runnerPosCurrent.y + " has been set to: " + mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y]);

        Vector2 runnerPosNext = runnerPosCurrent;

        Vector2 newDirection = RandomDirVector();   // Get new direction

        runnerPosNext += newDirection;              // Set next runner's position in array

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
                RunnerRandom(runnerPosNext, runnerDistance - 1);
            }
        }
    }




    void RunnerSteering(Vector2 runnerPosCurrent, int runnerDistance, Vector2 previousDirection) //Runner that can't go back on itself
    {
        // Set given position as true
        mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y] = true;
        print("Map Array Entry " + (int)runnerPosCurrent.x + "," + (int)runnerPosCurrent.y + " has been set to: " + mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y]);

        Vector2 runnerPosNext = runnerPosCurrent;

        Vector2 newDirection = RandomDirVector(); // Get new direction

        while (newDirection == previousDirection) // Check if the new direction would be going back on itself
        {

            newDirection = RandomDirVector();
        }

        runnerPosNext += newDirection;           // Set next runner's position in array

        if ((runnerDistance - 1 > 0))           // Start next runner if not at goal
        {
            if ((runnerPosNext.x >= gridsize) | (runnerPosNext.y >= gridsize) | (runnerPosNext.x < 0) | (runnerPosNext.y < 0))
            {
                print("Whoops! Out of bounds");
            }
            else
            {
                print((runnerDistance - 1) + " steps to go");
                RunnerSteering(runnerPosNext, runnerDistance - 1, newDirection * -1);
            }
        }
    }

    void RunnerSteeringAlt(Vector2 runnerPosCurrent, int runnerDistance, Vector2 previousDirection) //Runner that can't go back on itself, instead it defaults to going straight
    {
        // Set given position as true
        mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y] = true;
        print("Map Array Entry " + (int)runnerPosCurrent.x + "," + (int)runnerPosCurrent.y + " has been set to: " + mapArray[(int)runnerPosCurrent.x, (int)runnerPosCurrent.y]);

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
            if ((runnerPosNext.x >= gridsize) | (runnerPosNext.y >= gridsize) | (runnerPosNext.x < 0) | (runnerPosNext.y < 0))
            {
                print("Whoops! Out of bounds");
            }
            else
            {
                print((runnerDistance - 1) + " steps to go");
                RunnerSteeringAlt(runnerPosNext, runnerDistance - 1, newDirection * -1);
            }
        }
    }
}
