using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndingDisplay : MonoBehaviour
{

		public bool failure1 = false, failure2 = false, failure3 = false, win = false;
		public Text winDisplay;

		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				string buffer = "";
				//Debug.Log ("win: " + win.ToString ());
				//Debug.Log ("failure1: " + failure1.ToString ());
				//Debug.Log ("failure2: " + failure2.ToString ());
				//Debug.Log ("failure3: " + failure3.ToString ());
				if (failure1) {
						buffer = "You should feel shame! Even if you save your own life, but others are lost.";
				} else if (failure2) {
						buffer = "You will be remembered along with other scientists";
				} else if (failure3) {
						buffer = "You are turely a hero. You save other with sacrfice of youself.";
				} else if (win) {
						buffer = "Congraz! You successfully save all the scientist and exit the facility!";
				}
				winDisplay.GetComponent<Text> ().text = buffer;
		}
}
