using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
            transform.Translate(Vector3.forward * Time.deltaTime * 5f * Input.GetAxis("Horizontal"));
    }
}
