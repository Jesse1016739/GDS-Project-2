using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
            collision.transform.position = SpawnPoint.position;

    }

}
