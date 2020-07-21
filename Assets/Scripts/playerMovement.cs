using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	Rigidbody rb;
	float dirX;
	float moveSpeed = 10f;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		dirX = Input.acceleration.x * moveSpeed;
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2, 2f), transform.position.y);
	}

	void FixedUpdate()
	{
		rb.AddForce(0, 0, 2000 * Time.deltaTime);
		rb.velocity = new Vector2(dirX, 0f);
	}
}
