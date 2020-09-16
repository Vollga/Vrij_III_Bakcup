using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public bool isEnabled = false;
    public GameObject roomAsset = null; 

    public void Enable()
    {
        isEnabled = true;
    }
}
