using UnityEngine;
using System.Collections;

public class DoorLogic : MonoBehaviour
{

		//Collider thingCurrentlyInside;
		//bool drawGUI = false;
		//bool doorIsClosed = true;

		private int count; //The number of colliders present that should open the door

		private Animator anim;
		public GameObject door;
		private GameObject player;

		void Awake ()
		{
				anim = door.GetComponent<Animator> ();
				anim.SetBool ("Open", false);
				player = GameObject.FindGameObjectWithTag ("Player");
		}

		//void Update ()
		//{
		//if (drawGUI == true && Input.GetKeyDown (KeyCode.E)) {
		//changeDoorState ();
		//}
		//}

		void OnTriggerEnter (Collider activator)
		{
				if (activator.gameObject == player) {
						count ++;
				}
		}

		void OnTriggerExit (Collider exitor)
		{
				if (exitor.tag == "Player") {
						count = Mathf.Max (0, count - 1);
				}
		}

		void Update ()
		{
				anim.SetBool ("Open", count > 0);
		}
		//void OnGUI ()
		//{
		//if (drawGUI == true) {
		//GUI.Box (new Rect (Screen.width * 0.5f - 55, Screen.height * 0.3f, 110, 22), "Press [E] to open");
		//}
		//}

		//void changeDoorState ()
		//{
		//if (anim.GetBool ("Open")) {
		//anim.SetBool ("Open", false);
		//} else {
		//anim.SetBool ("Open", true);
		//}
		//}
	
}
