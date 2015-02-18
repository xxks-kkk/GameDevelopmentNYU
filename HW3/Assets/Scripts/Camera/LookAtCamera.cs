using UnityEngine;
using System.Collections;

//This is the most basic 3rd person camera. 
//It sits in a fixed location in the 3D world and tracks its target like a turret.
public class LookAtCamera : MonoBehaviour
{

		public GameObject target;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		//As a rule of thumb, you should always use LateUpdate() instead of the Update() method in all camera scripts. 
		//LateUpdate() happens after Update() has finished, so the Player script has a chance to finish calculating the player's position before the camera calculates its position. 
		//This results in smoother camera motion
		void LateUpdate ()
		{
				transform.LookAt (target.transform);
		}
}
