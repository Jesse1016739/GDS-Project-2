using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    public float force = 20;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(transform.forward * force);
    }
}
