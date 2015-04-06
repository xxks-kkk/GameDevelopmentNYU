using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		public float speed;
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
				if (isGrounded ()) {
						GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
				}

				// move with the right click
				if (Input.GetMouseButtonDown (0)) {
						ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						rayHit = new RaycastHit ();
						Physics.Raycast (ray, out rayHit, 1000f);
				}

				movDir = rayHit.point - transform.position;
				//transform.position = Vector3.MoveTowards (transform.position, rayHit.point, speed * Time.deltaTime);
		}

		void FixedUpdate ()
		{
				GetComponent<Rigidbody> ().AddForce (movDir * 10);
		}

		void OnCollisionEnter (Collision other)
		{
				if (other.gameObject.tag == "NPC") {
						Application.LoadLevel (Application.loadedLevel);
				}
		}

	
		bool isGrounded ()
		{
				return Physics.Raycast (transform.position, -Vector3.up, collider.bounds.extents.y + 0.1f);
		}
}
