using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script changes the rotation of the skylight in regards to player position relative to its depth
public class Daylight : MonoBehaviour
{
    public Transform player;
    private float playerRelativeDepth;

    void Update()
    {
        if(player.position.z > 10.8) // surface
            playerRelativeDepth = 17.474f; 
        else if(player.position.z > 8.1 && player.position.z < 10.6) // top tier
            playerRelativeDepth = -1.878f; 
        else if(player.position.z > 5.4 && player.position.z < 7.7) // middle tier x
            playerRelativeDepth = -16.4f; 
        else if(player.position.z < 7.7) // core
            playerRelativeDepth = -22f; 
        // porpotionate number between -107 and -115 - lower number is brighter (9 notches)
        
        transform.localEulerAngles = new Vector3(playerRelativeDepth, transform.position.y, transform.position.z);
    }
}
