using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		public float speed = 15f;
		Rigidbody rbody;

		// Use this for initialization
		void Start ()
		{
				rbody = GetComponent<Rigidbody> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{
				rbody.AddForce (transform.forward * speed * Input.GetAxis ("Vertical"));
				rbody.AddForce (transform.right * speed * Input.GetAxis ("Horizontal"));
				if (Input.GetKeyDown (KeyCode.Space)) {
						rbody.AddForce (transform.up * 10, ForceMode.Impulse);
				}
		}
}
