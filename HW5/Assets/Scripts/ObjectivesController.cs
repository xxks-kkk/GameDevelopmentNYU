using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectivesController : MonoBehaviour
{

		public Text obj;
		GameObject[] scientists;
		GameObject GM;
		int numLeft;

		// Use this for initialization
		void Start ()
		{
				GM = GameObject.Find ("GameManager");
		}
	
		// Update is called once per frame
		void Update ()
		{
				scientists = GameObject.FindGameObjectsWithTag ("objectives");
				numLeft = scientists.Length;
				GM.GetComponent<GameManager> ().numScientistsLeft = numLeft;
				//Debug.Log ("numLeft: " + numLeft);
				obj.GetComponent<Text> ().text = "Scientists left: " + numLeft;
				
		}
}
