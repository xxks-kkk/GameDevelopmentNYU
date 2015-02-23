using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour
{

		private bool arrive = false;
		public GameObject elevator;
		


		void Update ()
		{	
				if (arrive) {
						transform.position += Vector3.up * Time.deltaTime;
				}

		}

		void OnCollisionEnter (Collision collision)
		{
				if (collision.gameObject.name == "Ball6") {
						arrive = true;
				} 
		}
	
}
