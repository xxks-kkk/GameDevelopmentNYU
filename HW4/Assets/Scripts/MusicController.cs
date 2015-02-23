using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{

		public GameObject BallMusic;
		public GameObject bgm;

		void OnCollisionEnter (Collision collision)
		{
				if (collision.gameObject.name == "Ball2") {
						bgm.GetComponent<AudioSource> ().Play ();
				}
		}
}
