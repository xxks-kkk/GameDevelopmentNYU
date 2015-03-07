using UnityEngine;
using System.Collections;

public class AreaCheck3 : MonoBehaviour
{
	
		GameObject GM, check1, check2, check3, check4;
		public bool insideCheck3 = false;
	
		void Awake ()
		{
				GM = GameObject.Find ("GameManager");
				check1 = GameObject.Find ("Check1");
				check2 = GameObject.Find ("Check2");
				check4 = GameObject.Find ("Check4");
		}
	
		void OnTriggerEnter (Collider activator)
		{
				if (activator.gameObject.tag == "Player") {
						GM.GetComponent<GameManager> ().insideFacility = true;
						insideCheck3 = true;
				}
				
		}
	
		void OnTriggerExit (Collider exitor)
		{
				if (exitor.gameObject.tag == "Player") {
						if (!check4.GetComponent<AreaCheck4> ().insideCheck4 && !check2.GetComponent<AreaCheck2> ().insideCheck2) {
								GM.GetComponent<GameManager> ().insideFacility = false;
						}
						insideCheck3 = false;
				}
		}
}
