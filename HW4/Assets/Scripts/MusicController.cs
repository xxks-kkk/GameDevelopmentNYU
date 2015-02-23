using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{

		public GameObject BallMusic;
		public GameObject bgm;
		public GameObject Ball4;
		private bool move = false;

		void OnCollisionEnter (Collision collision)
		{
				if (collision.gameObject.name == "Ball2") {
						bgm.GetComponent<AudioSource> ().Play ();
						move = true;
				}
		}

		void FixedUpdate ()
		{
				if (move) {
						Ball4.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 0.1f, ForceMode.Impulse);
				}
		}
}
