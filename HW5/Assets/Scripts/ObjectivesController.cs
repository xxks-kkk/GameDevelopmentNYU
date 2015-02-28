using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectivesController : MonoBehaviour
{

		public Text obj;
		GameObject[] scientists;
		int numLeft;

		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				scientists = GameObject.FindGameObjectsWithTag ("objectives");
				numLeft = scientists.Length;
				//Debug.Log ("numLeft: " + numLeft);
				obj.GetComponent<Text> ().text = "Scientists left: " + numLeft;
				
		}
}
