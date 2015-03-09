using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

		public bool insideFacility = false;
		public int numScientistsLeft;
		public float time;
		public float health;
		GameObject winDisplay;
		Slider PowerBarSlider;

		// Use this for initialization
		void Start ()
		{
				winDisplay = GameObject.Find ("Win");

				GameObject tmp = GameObject.Find ("PowerBarSlider");
				PowerBarSlider = tmp.GetComponent<Slider> ();
		}

		void Update ()
		{
				PowerBarSlider.value -= 0.02f;
		}
	
		
		void LateUpdate ()
		{
				//Debug.Log ("Time: " + time.ToString ("0"));
				//Debug.Log ("Time Compare: " + time.ToString ("0").Equals ("0"));
				if (numScientistsLeft == 0 && !insideFacility && time >= 0) {
						//Debug.Log ("Comes here!");
						winDisplay.GetComponent<EndingDisplay> ().win = true;
						
				} else if (time.ToString ("0").Equals ("0") && numScientistsLeft > 0 && !insideFacility) {
						//Debug.Log ("Come here!");
						winDisplay.GetComponent<EndingDisplay> ().failure1 = true;
						
				} else if (time.ToString ("0").Equals ("0") && numScientistsLeft > 0 && insideFacility) {
						winDisplay.GetComponent<EndingDisplay> ().failure2 = true;
						
				} else if (time.ToString ("0").Equals ("0") && numScientistsLeft == 0 && insideFacility) {
						winDisplay.GetComponent<EndingDisplay> ().failure3 = true;
						
				} else if (health <= 0) {
						winDisplay.GetComponent<EndingDisplay> ().failure4 = true;
				}
		}
}
