using UnityEngine;
using System.Collections;

//This type of camera is commonly used in platforming games like Mario Galaxy. 
//The camera sits behind and above the player and rotates around the character as they turn.
public class TheFollowCamera : MonoBehaviour
{
		public GameObject target;
		Vector3 offset;

		// Use this for initialization
		void Start ()
		{
				offset = target.transform.position - transform.position;
		}
	
		
		void LateUpdate ()
		{
				//To orient the camera behind the target, we first need to get
				//the angle of the target and turn it into a rotation
				float desiredAngle = target.transform.eulerAngles.z;
				Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);

				//we can then multiply the offset by the rotation to orient the offset the same as the target.
				//we then subtract the result from the position of the target.
				transform.position = target.transform.position - (rotation * offset);

				transform.LookAt (target.transform.position);
		}
}
