using UnityEngine;
using System.Collections;

public class PivotDoorLogic : MonoBehaviour
{

		bool drawGUI = false;
		int count;
		Animator anim;
		public GameObject door;
		GameObject player;

		void Awake ()
		{
				anim = door.GetComponent<Animator> ();
				anim.SetBool ("Open", false);
				player = GameObject.FindGameObjectWithTag ("Player");
		}

		void OnTriggerEnter (Collider activator)
		{
				if (activator.tag == "Player") {
						drawGUI = true;
						count ++;
				}
		}

		void OnTriggerExit (Collider exitor)
		{
				if (exitor.tag == "Player") {
						drawGUI = false;
						count = Mathf.Max (0, count - 1);
				}
		}
	
		void Update ()
		{
				if (drawGUI == true && Input.GetKeyDown (KeyCode.E)) {
						changeDoorState ();
				}
		}

		void OnGUI ()
		{
				if (drawGUI == true) {
						GUI.Box (new Rect (Screen.width * 0.5f - 55, Screen.height * 0.3f, 110, 22), "Press [E] to open");
				}
		}

		void changeDoorState ()
		{
				if (anim.GetBool ("Open")) {
						anim.SetBool ("Open", false);
				} else {
						anim.SetBool ("Open", true);
				}
		}

}
