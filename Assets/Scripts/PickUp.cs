using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform Destination;

    public void Pickup()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = Destination.position;
        this.transform.parent = GameObject.Find("Hands").transform;
    }
    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
     
    }
}
