using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform respawn;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("trigger");
        // move player to respawn position
        col.gameObject.transform.position = respawn.position;

    }
}
