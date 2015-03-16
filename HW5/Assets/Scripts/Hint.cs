using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{

		public Text dialog;
		string intro;

		// Use this for initialization
		void Start ()
		{
				intro = "Hello there! I'm one of scientists that just escaped the building in front of you. There are still a few my colleagues trapped in there." +
						"Please help them get out of it in 5 minutes because this research building is about to explode." +
						"You can use [shift] to sprint, [space] to jump, and [F] to activate your torchlight." +
						"Please be hurry!";

				dialog.GetComponent<Text> ().text = "";
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.tag == "Player") {
						dialog.GetComponent<Text> ().text = intro;
				}
		}

		void OnTriggerExit (Collider other)
		{
				if (other.tag == "Player") {
						dialog.GetComponent<Text> ().text = "";
				}
		}
}
