using UnityEngine;
using System.Collections;

public class MineControl : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag == "NPC") {
						Destroy (other.gameObject);
				}
				if (other.gameObject.tag == "Player") {
						Application.LoadLevel (Application.loadedLevel);
				}
		}

}
