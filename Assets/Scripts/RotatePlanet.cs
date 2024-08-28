using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.localEulerAngles+=new Vector3(0,Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
            //transform.Rotate(new Vector3(Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0, 0), Space.Self);
        }
    }
}
