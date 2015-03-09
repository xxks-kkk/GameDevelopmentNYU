using UnityEngine;
using System.Collections;

public class FlashLightController : MonoBehaviour
{

		public bool FlashLightOn = false;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetButtonDown ("toggleLight") && FlashLightOn == false) {
						light.intensity = 3;
						FlashLightOn = true;
				} else if (Input.GetButtonDown ("toggleLight") && FlashLightOn) {
						light.intensity = 0;
						FlashLightOn = false;
				}
		}
}
