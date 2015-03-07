using UnityEngine;
using System.Collections;

public class AreaCheck2 : MonoBehaviour
{



		GameObject GM, check1, check2, check3, check4;
		public bool insideCheck2 = false;
	
		void Awake ()
		{
				GM = GameObject.Find ("GameManager");
				check1 = GameObject.Find ("Check1");
				check3 = GameObject.Find ("Check3");
				check4 = GameObject.Find ("Check4");
		}
	
		void OnTriggerEnter (Collider activator)
		{
				if (activator.gameObject.tag == "Player") {
						GM.GetComponent<GameManager> ().insideFacility = true;
						insideCheck2 = true;
				}
				
		}
	
		void OnTriggerExit (Collider exitor)
		{
				if (exitor.gameObject.tag == "Player") {
						//Debug.Log ("Comes here!");
						if (!check1.GetComponent<AreaCheck1> ().insideCheck1 && !check3.GetComponent<AreaCheck3> ().insideCheck3) {
								GM.GetComponent<GameManager> ().insideFacility = false;
						}
						insideCheck2 = false;
				}
		}
}
