using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

		Ray ray;
		RaycastHit rayHit;
		Vector3 movDir;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				// move with the right click
				if (Input.GetMouseButtonDown (1)) {
						ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						rayHit = new RaycastHit ();
						Physics.Raycast (ray, out rayHit, 1000f);
				}

				movDir = rayHit.point - transform.position;
				
		}

		void FixedUpdate ()
		{
				GetComponent<Rigidbody> ().AddForce (movDir * 10);
		}
}
