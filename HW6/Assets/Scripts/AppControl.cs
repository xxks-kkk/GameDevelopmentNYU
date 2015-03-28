using UnityEngine;
using System.Collections;

public class AppControl : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				// did the player press [R] on the keyboard?
				if (Input.GetKeyDown (KeyCode.R)) {
						// if so, reload the current scene
						Application.LoadLevel (Application.loadedLevel);
				}
		}
}
