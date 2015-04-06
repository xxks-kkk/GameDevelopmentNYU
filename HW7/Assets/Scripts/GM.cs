using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
		public GameObject win;
		
		bool winMode = false;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (winMode) {
						win.GetComponent<Text> ().text = "Win!";
				} else {
						win.GetComponent<Text> ().text = "";
				}
		}

		void OnCollisionEnter (Collision other)
		{
				if (other.gameObject.tag == "Player") {
						winMode = true;
						
				}
		}
}
