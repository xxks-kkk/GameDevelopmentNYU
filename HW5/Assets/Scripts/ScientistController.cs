using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScientistController : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
			
			
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnCollisionEnter (Collision collision)
		{
				if (collision.gameObject.name == "Player") {
						Destroy (gameObject);
						//Reward on rescuing a scientist
						GameObject tmp = GameObject.Find ("Timer");
						tmp.GetComponent<TimerController> ().startTime += 10f;
						GameObject tmp2 = GameObject.Find ("PowerBarSlider");
						tmp2.GetComponent<Slider> ().value += 10f;
				}
		}
}
