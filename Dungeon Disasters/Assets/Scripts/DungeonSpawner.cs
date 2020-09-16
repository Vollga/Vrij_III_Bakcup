using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public List<GameObject> BasicDraw(bool[,] mapArray, GameObject tilePrefab)
    {
        List<GameObject> roomsList = new List<GameObject>();

        for (int iZ = 0; iZ < mapArray.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < mapArray.GetLength(0); iX++)
            {
                if (mapArray[iX, iZ] == true)
                {
                    roomsList.Add(Instantiate(tilePrefab, new Vector3(iX - (mapArray.GetLength(0) / 2) + this.transform.position.x, 0, iZ - (mapArray.GetLength(1) / 2) + this.transform.position.z), Quaternion.identity));
                }
            }
        }
        return roomsList;
    }

}
