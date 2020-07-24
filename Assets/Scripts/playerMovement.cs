using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody rb;
	float dirX;
	float dirZ;
	public float moveSpeed = 0.05f;
	public bool motionControls;
	public bool isColliding = false;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if (isColliding == true)
		{
			moveSpeed = 0;
		}
		
		else if(isColliding == false)
		{
			moveSpeed = 0.01f;
		}
	}

	void OnCollisionEnter(Collision obsColl)
	{
		if(obsColl.gameObject.tag == "Obstacle")
		{
			isColliding = true;
		}
	}
	void OnCollisionExit(Collision obsNullColl)
	{
		if (obsNullColl.gameObject.tag == "Obstacle")
		{
			isColliding = false;
		}
	}

	void FixedUpdate()
	{
		if (motionControls){ dirX = Input.acceleration.x * moveSpeed; }
        else 
		{ 
			dirX = Input.GetAxis("Horizontal"); 
		}
		
		if (isColliding == false)
		{
			dirZ = transform.position.z + moveSpeed;
		}
		
			
		if (dirZ > 22.34f)
			{
				//need to trigger next level generation
				dirZ = 0.8f;
			}
		transform.position = new Vector3(Mathf.Clamp(transform.position.x + dirX, -2, 2f), transform.position.y, transform.position.z + moveSpeed);
	}
}
