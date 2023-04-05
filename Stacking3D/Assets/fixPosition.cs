using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixPosition : MonoBehaviour
{
    public GameObject thisOBJ;
    Rigidbody rb;
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            rb.constraints = RigidbodyConstraints.None;
    }
}