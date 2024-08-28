using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMesh : MonoBehaviour
{
    // Assigns an arbitrary mesh collider to the current transform

    [SerializeField] Mesh meshToCollide;

    void Start()
    {
        if (!meshToCollide)
        {
            Debug.LogError("Assign a mesh in the inspector");
            return;
        }
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = meshToCollide;
        meshCollider.convex = true;
    }
}
