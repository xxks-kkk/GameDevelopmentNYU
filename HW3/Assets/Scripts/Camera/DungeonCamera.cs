using UnityEngine;
using System.Collections;

//This is the type of camera you'd typically find in games like Diablo, also known as a "dungeon crawler" game. 
//The camera sits above the player and moves relative to the character, but never rotating.
public class DungeonCamera : MonoBehaviour
{

		public GameObject target;
		//store the offset between the camera and its target. 
		//The offset is represented as a Vector3 and will be used maintain the relative distance as the player moves around.
		Vector3 offset; 
		//control how much damping is applied
		public float damping = 1;

		// Use this for initialization
		void Start ()
		{
				offset = transform.position - target.transform.position;
		}
	
		// In each frame we need to update the camera's position based on
		// the player's position by applying the offset. 
		void LateUpdate ()
		{
				Vector3 desiredPos = target.transform.position + offset;
				//The camera movement is a bit stiff. It would be nice to dampen the movement slightly so that it
				//takes some time to catch up to the player. We can do this using the Vector3.Lerp() method. Lerp linearly
				//interpolates between two points, meaning it smoothly transitions from one point to another in a straight line.
				//The two points we can lerp between are the current position of the camera with damping applied, and the desired position without damping.		
				
				Vector3 position = Vector3.Lerp (transform.position, desiredPos, Time.deltaTime * damping);
				transform.position = position;
				
				//transform.position = desiredPos;
				transform.LookAt (target.transform.position);
		}
}
