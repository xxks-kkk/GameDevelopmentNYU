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
		GameObject flashLight;
		Slider HealthBarSlider;
		GameObject player;

		// Use this for initialization
		void Start ()
		{
				winDisplay = GameObject.Find ("Win");

				GameObject tmp = GameObject.Find ("PowerBarSlider");
				PowerBarSlider = tmp.GetComponent<Slider> ();

				GameObject tmp2 = GameObject.Find ("HealthBarSlider");
				HealthBarSlider = tmp2.GetComponent<Slider> ();

				flashLight = GameObject.Find ("FlashLight");
				
				player = GameObject.Find ("Player");
		}

		void Update ()
		{
				if (flashLight.GetComponent<FlashLightController> ().FlashLightOn) {
						PowerBarSlider.value -= 0.9f * Time.deltaTime;
				} else {
						PowerBarSlider.value += 0.8f * Time.deltaTime;
				}
		}
	
		
		void LateUpdate ()
		{
				//Debug.Log ("Time: " + time.ToString ("0"));
				//Debug.Log ("Time Compare: " + time.ToString ("0").Equals ("0"));
				if (numScientistsLeft == 0 && !insideFacility && time >= 0) {
						//Debug.Log ("Comes here!");
						winDisplay.GetComponent<EndingDisplay> ().win = true;
						lockScreen ();
						
				} else if (time.ToString ("0").Equals ("0") && numScientistsLeft > 0 && !insideFacility) {
						//Debug.Log ("Come here!");
						winDisplay.GetComponent<EndingDisplay> ().failure1 = true;
						lockScreen ();
						
						
				} else if (time.ToString ("0").Equals ("0") && numScientistsLeft > 0 && insideFacility) {
						winDisplay.GetComponent<EndingDisplay> ().failure2 = true;
						lockScreen ();
						
						
				} else if (time.ToString ("0").Equals ("0") && numScientistsLeft == 0 && insideFacility) {
						winDisplay.GetComponent<EndingDisplay> ().failure3 = true;
						lockScreen ();
						
						
				} else if (HealthBarSlider.value <= 0) {
						winDisplay.GetComponent<EndingDisplay> ().failure4 = true;
						lockScreen ();
				}
		}

		void lockScreen ()
		{
				//when game ends, lock screen
				player.GetComponent<MouseLook> ().enabled = false;
				player.GetComponent<PlayerController> ().enabled = false;
				Camera.main.GetComponent<MouseLook> ().enabled = false;
		}
}
