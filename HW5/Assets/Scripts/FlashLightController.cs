using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashLightController : MonoBehaviour
{

		public bool FlashLightOn = false;
		Slider PowerBarSlider;

		// Use this for initialization
		void Start ()
		{
				GameObject tmp = GameObject.Find ("PowerBarSlider");
				PowerBarSlider = tmp.GetComponent<Slider> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (PowerBarSlider.value > 0) {
						if (Input.GetButtonDown ("toggleLight") && FlashLightOn == false) {
								light.intensity = 3;
								FlashLightOn = true;
						} else if (Input.GetButtonDown ("toggleLight") && FlashLightOn) {
								light.intensity = 0;
								FlashLightOn = false;
						}
				} else {
						FlashLightOn = false;
						light.intensity = 0;
				}
		}
}
