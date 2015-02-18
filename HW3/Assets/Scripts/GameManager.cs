using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

		private GameObject info, treasure, ship, arch4, arch2;
		private Vector3 treasurePos, shipPos, arch4Pos, arch2Pos, iniPos;
		private float dist, dist2, dist4;
		private bool win = false;
		private Quaternion iniRotation;

		//private string textBuffer = "";

		// Use this for initialization
		void Start ()
		{
				treasure = GameObject.Find ("treasure");
				info = GameObject.Find ("Text");
				ship = GameObject.Find ("spaceship");
				arch4 = GameObject.Find ("arch4");
				arch2 = GameObject.Find ("arch2");
				iniPos = ship.transform.position;
				iniRotation = ship.transform.rotation;
		}
	
		// Update is called once per frame
		void Update ()
		{
				string textBuffer = "";
				treasurePos = treasure.GetComponent<Transform> ().position;
				shipPos = ship.GetComponent<Transform> ().position;
				arch4Pos = arch4.GetComponent<Transform> ().position;
				arch2Pos = arch2.GetComponent<Transform> ().position;

				dist = Vector3.Distance (treasurePos, shipPos);
				dist2 = Vector3.Distance (arch2Pos, shipPos);
				dist4 = Vector3.Distance (arch4Pos, shipPos);
				//textBuffer += "Distance from ship to treasure: " + dist;
				if (dist >= 1000)
						textBuffer += "You know there is a treasure on this wanderland!";
				else if (dist < 1000 && dist >= 500)
						textBuffer += "You're approaching. That's right, you're approaching";
				else if (dist < 500 && dist >= 200)
						textBuffer += "Wow, you can almost see it";
				else {
						textBuffer += "Congratz! You just found it! \n\n press [space] to claim your glory!";
						if (Input.GetKeyDown (KeyCode.Space) && !win) {
								win = true;
						}
				}
				if (dist2 <= 200) {
						textBuffer += "\nYou just discovered Daily Planet! A secret message shows that treasure is located somewhere in the woods";
				}
				if (dist4 <= 200) {
						textBuffer += "\nThis bizarre building implies you a new message about treasure: something will never be seen unless it is under the light";
				}
				
				
				if (win) {
						textBuffer += "\n\n A alien artifact has been discovered. You acquired a free technology for your civilization!";
						textBuffer += "\n Press[R] to restart";
				}
				
				if (Input.GetKeyDown (KeyCode.R)) {
						reset ();
				}

			

				info.GetComponent<Text> ().text = textBuffer;

		}

		void reset ()
		{
				ship.transform.position = iniPos;
				win = false;
				ship.transform.rotation = iniRotation;
		}
}
