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
        float massProduct = attractor.mass * target.mass * G;

        Vector3 difference = attractor.position - target.position;
        float distance = difference.magnitude;

        float unscaledForceMagnitue = massProduct / Mathf.Pow(distance, 2);
        float forceMagnitude = G * unscaledForceMagnitue;

        Vector3 forceDirection = difference.normalized;

        Vector3 forceVector = forceDirection * forceMagnitude;
        target.AddForce(forceVector);

    }

    private void Update()
    {
        AddGravityForce(attractor, target);
    }
}
