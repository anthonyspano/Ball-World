using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawn;

    void OnCollisionExit(Collision col)
    {
        Debug.Log("exited ground");
        if(col.gameObject.CompareTag("Ground"))
        {   
            Debug.Log("respawning soon");
            StartCoroutine(GoToRespawn());
        }
    }

    IEnumerator GoToRespawn()
    {
        yield return new WaitForSeconds(3.5f);

        transform.position = respawn.position;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
