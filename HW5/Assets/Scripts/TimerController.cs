using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

		float timer = 200.0f;
		public Text time;
	

		// Update is called once per frame
		void Update ()
		{
				timer -= Time.deltaTime;

				if (timer <= 0) {
						timer = 0;
				}
				time.GetComponent<Text> ().text = timer.ToString ("0");
		}
}
