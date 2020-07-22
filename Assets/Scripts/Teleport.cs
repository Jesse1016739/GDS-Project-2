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
    public float respawnTimer;
    public float respawnCountdown;

    void Update()
    {

        targetNumber = Random.Range(0, 1);
        typeOfTarget = targetTypes[targetNumber];
        //Debug.Log(targetNumber);

        targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length <= 0)
        {
            isClear = true;
        }

        if (isClear == true)
        {
            respawnCountdown -= Time.deltaTime;

            //StartCoroutine("targetReset");
        }

        if (respawnCountdown <= 0)
        {
            Instantiate(typeOfTarget, targetSpawnPoints[0].transform.transform);
            Instantiate(typeOfTarget, targetSpawnPoints[1].transform.transform);
            Instantiate(typeOfTarget, targetSpawnPoints[2].transform.transform);
            Debug.Log("Spawned new targets");
            isClear = false;
            respawnCountdown = respawnTimer;
        }
    }

    /*
    IEnumerator targetReset()
    {
        yield return new WaitForSeconds(respawnTimer);
        Instantiate(typeOfTarget, targetSpawnPoints[0].transform.transform);
        Debug.Log("Left Firing");
        Instantiate(typeOfTarget, targetSpawnPoints[1].transform.transform);
        Debug.Log("Left Firing");
        Instantiate(typeOfTarget, targetSpawnPoints[2].transform.transform);
        Debug.Log("Left Firing");
        isClear = false;
        Debug.Log(isClear);

    }
    */

    [SerializeField] Transform SpawnPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            collision.transform.position = SpawnPoint.position;
        }
    }

}
