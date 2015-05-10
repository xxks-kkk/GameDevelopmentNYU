using UnityEngine;
using System.Collections;

public class EnemyControllerAdv : MonoBehaviour
{
	public Transform player;
	public Transform gizmo;
	public Transform playerGizmo;

	public float speed = 5f;
	public float rotationDamping = 1;
	public float moveDetectionDist = 1f;
	public float attackRange = 5f;

	float playerDistance;
	float bestDistance = 9999999f;
	public bool getClosetPos = false;
	bool exitObstacles = true;
	bool transitionState = false;
	bool nextState = false;
	bool doOnce = true;
	bool doOnce2 = true;
	bool doOnce3 = true;
	bool turnAround = false;
	public bool startWalkAroundObstacles = false;
	Vector3 startPos;
	Vector3 closestPos;

	Vector3 errorBound = new Vector3 (0.1f, 0f, 0.5f);

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (canMoveTowardsPlayer ()) {
			lookAtPlayer ();
			playerDistance = Vector3.Distance (player.position, transform.position);
			if (playerDistance < attackRange) {
				attack ();
			} else {
				chase ();
			}
		} else if (player != null) {
			if (!transitionState) {
				chase ();
			} 

			RaycastHit hit;
			RaycastHit hit2;

			if (!exitObstacles) {
				//Debug.Log ("PlayerDistance: " + playerDistance);
				//Debug.Log ("BestDistance: " + bestDistance);
				playerDistance = Vector3.Distance (player.position, transform.position);
				if (playerDistance < bestDistance) {
					bestDistance = playerDistance;
					//Debug.Log ("closesetPos: " + closestPos);
					closestPos = transform.position;
				}
			}

			// we already circumnavigate the obstacle once, and we should find the closet position to the goal
			// now, we need to return to the closest position
			//Debug.Log ("startWalkAroundObstacles: " + startWalkAroundObstacles);
			//Debug.Log ("transform.position: " + transform.position);
			//Debug.Log ("startPos: " + startPos);



			Vector3 error = transform.position - startPos;
			//Debug.Log ("error: " + (transform.position - startPos));
			if (Mathf.Abs (error.x) <= 0.1f && Mathf.Abs (error.z) <= 0.5f && startWalkAroundObstacles) {
				getClosetPos = true;
			}

			Debug.Log ("getClosetPos: " + getClosetPos);
			// we reach the closest position and continue walk towards the goal

			Vector3 error2 = transform.position - closestPos;

			if (getClosetPos) {
				Debug.Log ("error2: " + error2);
				Debug.Log ("closestPos: " + closestPos);
				Debug.Log ("transform.position: " + transform.position);
			}

			if (getClosetPos && Mathf.Abs (error2.x) <= 0.1f && Mathf.Abs (error2.z) <= 0.5f && !nextState) {
				transitionState = true;

				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				Quaternion rotation = Quaternion.identity;
				if (doOnce3) {
					rotation = Quaternion.LookRotation (player.position - transform.position);
					doOnce3 = false;
				}
				Debug.Log ("rotation: " + rotation);
				Debug.Log ("Angle: " + Quaternion.Angle (rotation, transform.rotation));

				//float minAngle = 999f;
				//float prevMinAngle = 0f;

				//prevMinAngle = Quaternion.Angle (rotation, transform.rotation);

				//if (prevMinAngle < minAngle) {
				//	minAngle = prevMinAngle;
				//} 

				if (Quaternion.Angle (rotation, transform.rotation) >= 10f) {
					lookAtPlayer ();
				} else {
					nextState = true;
				}
			}

			if (nextState) {

			}


			if (Physics.Raycast (transform.position, transform.forward, out hit, moveDetectionDist)) {
				transform.Rotate (0f, -90f, 0f);
				if (!startWalkAroundObstacles) {
					startPos = transform.position;
					//Debug.Log ("startPos: " + transform.position);
					startWalkAroundObstacles = true;
					exitObstacles = false;

					//GameObject wayPoint = Instantiate (Resources.Load ("WayPoint", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
					//wayPoint.transform.position = transform.position;
				}
			}

			if (!Physics.Raycast (gizmo.position, gizmo.right, out hit2, moveDetectionDist) && !turnAround) {

				turnAround = true;
				if (!startWalkAroundObstacles) {
					startPos = transform.position;
					//Debug.Log ("startPos: " + transform.position);
					startWalkAroundObstacles = true;
					exitObstacles = false;
					//GameObject wayPoint = Instantiate (Resources.Load ("WayPoint", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
					//wayPoint.transform.position = transform.position;
				}
			}

			if (turnAround) {
				if (doOnce) {
					doOnce = false;
					transform.Rotate (0f, 90f, 0f);
				}
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
			
				turnAround = false;
			} else {
				doOnce = true;
				if (!transitionState) {
					GetComponent<Rigidbody> ().velocity = transform.forward * speed;
				}
			}
		} 	

	}

	bool canMoveTowardsPlayer ()
	{
		if (player != null) {
			Quaternion rotation = Quaternion.LookRotation (player.position - playerGizmo.position);
			playerGizmo.rotation = Quaternion.Slerp (playerGizmo.rotation, rotation, Time.deltaTime * 10f);
			RaycastHit hit;
			if (Physics.Raycast (playerGizmo.position, playerGizmo.forward, out hit)) {
				if (hit.collider.gameObject.tag == "Player") {
					return true;
				}
			}
			return false;
		} else {
			return false;
		}
	}

	void lookAtPlayer ()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}

	void chase ()
	{
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	void attack ()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (hit.collider.gameObject.tag == "Player") {
				hit.collider.gameObject.GetComponent<PlayerController> ().health -= 1f;
			}
		}
	}

	void reset ()
	{
		bestDistance = 9999999f;
		getClosetPos = false;
		exitObstacles = true;
		doOnce = true;
		turnAround = false;
		startWalkAroundObstacles = false;
		transitionState = false;
	}
	
}
