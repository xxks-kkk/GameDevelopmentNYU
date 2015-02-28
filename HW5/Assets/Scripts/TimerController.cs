using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
		float startTime = 5 * 60f; // startTime is set in minutes
		string timer;
		public Text time;

		void Start ()
		{
				//TODO: need to adjust text box to make it looks perfect
				//time.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (Screen.height - 10, Screen.height - 10);
				//time.GetComponent<RectTransform> ().sizeDelta = new Vector2 (40, 30);
		}
		void Update ()
		{
				startTime -= Time.deltaTime;

				if (startTime <= 0) {
						startTime = 0;
				}

				int minutes = (int)startTime / 60;
				int seconds = (int)startTime % 60;
				timer = string.Format ("{0:00}:{1:00}", minutes, seconds);

				time.GetComponent<Text> ().text = timer;
		}
		
}
