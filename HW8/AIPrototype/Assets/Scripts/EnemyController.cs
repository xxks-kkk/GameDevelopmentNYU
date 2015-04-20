using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

	public Transform player;
	public float playerDistance;
	public float visionDistance;
	public float visionSpread = 45f; // angle between (npc's forward direction) and (line from npc to player)
	public float rotationDamping;
	public float chaseStartRange;
	public float speed;
	public float attackRange = 2f;

	bool canSeePlayer = false;


	bool turnAround = false;
	bool doOnce = true;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (!canSeePlayer) {
			patrol ();
		}


		if (PlayerController.isPlayerAlive) {
			playerDistance = Vector3.Distance (player.position, transform.position);
	
			RaycastHit hit;

			if (playerDistance < visionDistance && 
				Vector3.Angle (player.position - transform.position, transform.forward) < visionSpread && 
				Physics.Raycast (transform.position, player.position - transform.position, out hit, visionDistance) && 
				hit.collider.gameObject.tag == "Player") {
				canSeePlayer = true;
				lookAtPlayer ();
			} else {
				canSeePlayer = false;
			}

			if (playerDistance < chaseStartRange) {
				if (playerDistance > attackRange) {
					chase (); 
				} else {
					attack ();
				}
			}
		}
	}

	void lookAtPlayer ()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}

	void patrol ()
	{

		Ray ray = new Ray (transform.position, transform.forward);
		if (turnAround) {
			if (doOnce) {
				doOnce = false;
				
				//transform.Rotate (0f, 90f, 0f);
				//transform.Rotate (0f, -90f, 0f);
				transform.Rotate (0f, 180f, 0f);
			}
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			
			turnAround = false;
		} else {
			doOnce = true;
			GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		}
		
		if (Physics.Raycast (ray, 1f) && !turnAround) {
			turnAround = true;
			
		} 
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
