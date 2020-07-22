using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Teleport : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject[] targetSpawnPoints;
    public GameObject[] targetTypes;
    public bool isClear = false;
    public GameObject typeOfTarget;
    public int targetNumber;

    void Update()
    {

        //targetNumber = Random.Range(0, 1);
        typeOfTarget = targetTypes[Random.Range(0, 1)];

        targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length <= 0)
        {
            isClear = true;
        }

        if (isClear == true)
        {
            StartCoroutine("targetReset");
        }
    }

    public void targetReset()
    {
        Instantiate(typeOfTarget, targetSpawnPoints[0].transform.transform);
        Instantiate(typeOfTarget, targetSpawnPoints[1].transform.transform);
        Instantiate(typeOfTarget, targetSpawnPoints[2].transform.transform);
        isClear = false;
    }

    [SerializeField] Transform SpawnPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            collision.transform.position = SpawnPoint.position;
        }
    }

}
