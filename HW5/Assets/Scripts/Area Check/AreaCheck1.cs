using UnityEngine;
using System.Collections;

// Used to detect whether the player is inside the facility or not
public class AreaCheck1 : MonoBehaviour
{
		GameObject GM, check1, check2, check3, check4;
		public bool insideCheck1 = false;

		void Awake ()
		{
				GM = GameObject.Find ("GameManager");
				check2 = GameObject.Find ("Check2");
				check3 = GameObject.Find ("Check3");
				check4 = GameObject.Find ("Check4");
		}

		void OnTriggerEnter (Collider activator)
		{
				if (activator.gameObject.tag == "Player") {
						GM.GetComponent<GameManager> ().insideFacility = true;
				}
				insideCheck1 = true;
		}
	
		void OnTriggerExit (Collider exitor)
		{
				//Debug.Log ("Exit to check1");
				if (exitor.gameObject.tag == "Player") {
						//Debug.Log ("Comes here");
						//Debug.Log ("insideCheck2 :" + check2.GetComponent<AreaCheck2> ().insideCheck2.ToString ());
						if (!check2.GetComponent<AreaCheck2> ().insideCheck2) {
								GM.GetComponent<GameManager> ().insideFacility = false;
						}
						insideCheck1 = false;
				}
		}
}
