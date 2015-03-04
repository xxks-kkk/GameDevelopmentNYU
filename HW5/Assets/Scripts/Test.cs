using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
		public Text test;
		GameObject GM;

		// Use this for initialization
		void Start ()
		{
				GM = GameObject.Find ("GameManager");
		}
	
		// Update is called once per frame
		void Update ()
		{
				string buffer = "";
				buffer = GM.GetComponent<GameManager> ().insideFacility.ToString ();
				
				test.GetComponent<Text> ().text = buffer;
		}
}
