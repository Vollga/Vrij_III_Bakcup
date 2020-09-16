using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Room Set",menuName ="Room Set")]
public class DungeonDict : ScriptableObject
{
    [Header("Entrances")]
    public GameObject[] Entrance;
    [Header("Boss Rooms")]
    public GameObject[] BossUp;
    public GameObject[] BossRight;
    public GameObject[] BossDown;
    public GameObject[] BossLeft;
    [Header("End Rooms")]
    public GameObject[] EndUp;
    public GameObject[] EndRight;
    public GameObject[] EndDown;
    public GameObject[] EndLeft;
    [Header("Corridors")]
    public GameObject[] CorridorHorizontal;
    public GameObject[] CorridorVertical;
    [Header("Corners")]
    public GameObject[] CornerUpRight;
    public GameObject[] CornerUpLeft;
    public GameObject[] CornerDownRight;
    public GameObject[] CornerDownLeft;
    [Header("T Sections")]
    public GameObject[] TUp;
    public GameObject[] TRight;
    public GameObject[] TDown;
    public GameObject[] TLeft;
    [Header("Center Rooms")]
    public GameObject[] Center;
}
