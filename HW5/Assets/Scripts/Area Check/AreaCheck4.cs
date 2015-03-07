using UnityEngine;
using System.Collections;

public class AreaCheck4 : MonoBehaviour
{

		GameObject GM, check1, check2, check3, check4;
		public bool insideCheck4 = false;
	
		void Awake ()
		{
				GM = GameObject.Find ("GameManager");
				check1 = GameObject.Find ("Check1");
				check2 = GameObject.Find ("Check2");
				check3 = GameObject.Find ("Check3");
		}
	
		void OnTriggerEnter (Collider activator)
		{
				if (activator.gameObject.tag == "Player") {
						GM.GetComponent<GameManager> ().insideFacility = true;
						insideCheck4 = true;
				}
				
		}
	
		void OnTriggerExit (Collider exitor)
		{
				if (exitor.gameObject.tag == "Player") {
						if (!check3.GetComponent<AreaCheck3> ().insideCheck3) {
								GM.GetComponent<GameManager> ().insideFacility = false;
						}
						insideCheck4 = false;
				}
		}
}
