using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Teleport : MonoBehaviour
{ 
    public TargetSpawning spawning;

    [SerializeField] Transform SpawnPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            spawning.playerReset = true;
            collision.transform.position = SpawnPoint.position;
        }
    }

}
