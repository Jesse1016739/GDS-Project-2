using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Material hitMaterial;

    public scoringSys scoreSys;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                var rig = hitInfo.collider.GetComponent<Rigidbody>();
                if (rig != null)
                {
                    scoreSys.currentScore += 1;
                    Destroy(hitInfo.collider.gameObject);
                    
                    //hitInfo.collider.GetComponent<Collider>().enabled = false;
                    //rig.GetComponent<MeshRenderer>().material = hitMaterial;
                    //rig.AddForceAtPosition(ray.direction * 50f, hitInfo.point, ForceMode.VelocityChange);
                }
            }
        }


    }
}
