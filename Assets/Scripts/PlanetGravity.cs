using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    // gravity modifier
    private float gravityModifier;
    [SerializeField] private float G;
    public float Gravity;
    public Rigidbody attractor;
    public Rigidbody target;

    public Transform player;

    public void AddGravityForce(Rigidbody attractor, Rigidbody target)
    {
        G = Gravity * gravityModifier;
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
        if(player.position.z > 10.8) // surface
            gravityModifier = 3f; 
        else if(player.position.z > 8.1 && player.position.z < 10.6) // top tier
            gravityModifier = 2.2f; 
        else if(player.position.z > 5.4 && player.position.z < 7.7) // middle tier x
            gravityModifier = 1.8f; 
        else if(player.position.z < 7.7) // core
            gravityModifier = 1f; 

        AddGravityForce(attractor, target);
    }
}
