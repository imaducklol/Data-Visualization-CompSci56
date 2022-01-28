using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTeleport : MonoBehaviour
{
    Vector3 startCoords = new Vector3(-31.875f, 1, 18.375f);
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Endzone")) {
            this.gameObject.transform.position = startCoords;
        }
    }
}
