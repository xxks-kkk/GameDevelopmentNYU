using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{

		//public float speed;

	
		// Update is called once per frame
		//void Update ()
		//{
		//float transV = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		//float transH = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

		//transform.Translate (transH, 0, transV);
		//}



		public float movementSpeed = 10;
		public float turningSpeed = 60;
		
		void Update ()
		{
				transform.rotation = Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0); //lock the rotation of the ship
				float horizontal = Input.GetAxis ("Horizontal") * turningSpeed * Time.deltaTime;
				transform.Rotate (0, horizontal, 0);
			
				float vertical = Input.GetAxis ("Vertical") * movementSpeed * Time.deltaTime;
				transform.Translate (0, 0, vertical);
		}
	
}
