using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawning : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject[] targetSpawnPoints;
    public GameObject[] targetTypes;
    public bool isClear = false;
    public GameObject typeOfTarget;
    public int targetNumber;
    public float respawnTimer;
    public float respawnCountdown;

    public bool playerReset;

    void Update()
    {

        targetNumber = Random.Range(0, 1);
        typeOfTarget = targetTypes[targetNumber];
        //Debug.Log(targetNumber);

        //Counts the number of targets in a scene.
        targets = GameObject.FindGameObjectsWithTag("Target");

        //checks whether there are any targets in the scene
        if (targets.Length <= 0)
        {
            isClear = true;
        }

        if(playerReset == true)
        {

            for (int i = 0; i < targets.Length; i++)
            {
                Destroy(targets[i].gameObject);
                Debug.Log("Destroyed targets");
            }
        }

        //If it is clear, it be
        if (isClear == true)
        {
            //Minuses time away from the countdown.
            //respawnCountdown -= Time.deltaTime;
            playerReset = false;
            for (int i = 0; i < targetSpawnPoints.Length; i++)
            {
                Instantiate(typeOfTarget, targetSpawnPoints[i].transform.transform);
                Debug.Log("Spawned new targets");
            }
            isClear = false;


            //StartCoroutine("targetReset");
        }

        //When the countdown hits 0 or less, it will spawn new targets.
        /*
        if (respawnCountdown <= 0)
        {
            Instantiate(typeOfTarget, targetSpawnPoints[0].transform.transform);
            Instantiate(typeOfTarget, targetSpawnPoints[1].transform.transform);
            Instantiate(typeOfTarget, targetSpawnPoints[2].transform.transform);
            Debug.Log("Spawned new targets");
            isClear = false;
            respawnCountdown = respawnTimer;
        }
        */
    }

    //Old code that decided to say no
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
}
