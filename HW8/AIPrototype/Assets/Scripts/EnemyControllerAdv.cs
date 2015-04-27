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
	bool doOnce = true;
	bool turnAround = false;

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
			chase ();
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, moveDetectionDist)) {
				transform.Rotate (0f, -90f, 0f);
			}

			if (!Physics.Raycast (gizmo.position, gizmo.right, out hit, moveDetectionDist) && !turnAround) {

				turnAround = true;

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
				GetComponent<Rigidbody> ().velocity = transform.forward * speed;
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
	
}
