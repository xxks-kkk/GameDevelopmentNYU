using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

		public GameObject ball;
		public GameObject cameraTarget;

		void FixedUpdate ()
		{
				if (ball.name == "Ball") {
						ball.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 0.2f, ForceMode.Impulse);
				}
		}
		void OnCollisionEnter (Collision collision)
		{
				if (collision.gameObject.name == "hammer")
						ball.GetComponent<Rigidbody> ().AddForce (-1f * Vector3.forward * 0.2f, ForceMode.Impulse);

				if (collision.gameObject.name == "Domino") {
						ball.GetComponent<Rigidbody> ().AddForce (1f * Vector3.forward * 0.2f, ForceMode.Impulse);
						cameraTarget.GetComponent<CameraTargetController> ().speed = 2.7f;
				}
		}
}
