﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		public float speed = 15f;
		Rigidbody rbody;
		float distToGround;

		// Use this for initialization
		void Start ()
		{
				rbody = GetComponent<Rigidbody> ();

				// get the distance to ground
				distToGround = collider.bounds.extents.y;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{
				rbody.AddForce (transform.forward * speed * Input.GetAxis ("Vertical"));
				rbody.AddForce (transform.right * speed * Input.GetAxis ("Horizontal"));
				if (Input.GetKeyDown (KeyCode.Space) && isGrounded ()) {
						rbody.AddForce (transform.up * 10, ForceMode.Impulse);
				}
		}
		
		bool isGrounded ()
		{
				return Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.1f);
		}
		
}