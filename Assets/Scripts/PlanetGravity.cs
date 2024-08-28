using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    // gravity modifier
    public float G;
    public Rigidbody attractor;
    public Rigidbody target;

    public void AddGravityForce(Rigidbody attractor, Rigidbody target)
    {
        //Debug.Log(attractor);
        //Debug.Log(target);

        float massProduct = attractor.mass * target.mass * G;
        //Debug.Log(massProduct);

        Vector3 difference = attractor.position - target.position;
        float distance = difference.magnitude;

        float unscaledForceMagnitue = massProduct / Mathf.Pow(distance, 2);
        float forceMagnitude = G * unscaledForceMagnitue;

        Vector3 forceDirection = difference.normalized;
        Debug.Log(forceDirection);
        Debug.Log(forceMagnitude);

        Vector3 forceVector = forceDirection * forceMagnitude;
        target.AddForce(forceVector);
        //Debug.Log(forceVector);

    }

    private void Update()
    {
        AddGravityForce(attractor, target);
    }
}
