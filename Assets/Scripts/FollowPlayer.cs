using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform objectToFollow;


    void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x, transform.position.y, objectToFollow.position.z + 1);   
        //transform.position = new Vector3(objectToFollow.position.x, transform.position.y, transform.position.z);   
    }
}
