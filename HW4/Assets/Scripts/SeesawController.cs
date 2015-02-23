using UnityEngine;
using System.Collections;

public class SeesawController : MonoBehaviour
{

		//This script is not used. Put here for legacy.
		public GameObject seesaw;
		private bool rotate = false;

		void Update ()
		{
				if (!rotate) {
						seesaw.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
				} else {
						seesaw.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePosition;
				}
		}

		void OnCollisionEnter (Collision collision)
		{
				if (collision.gameObject.name == "Ball3")
						
						rotate = true;
						
		}
}
