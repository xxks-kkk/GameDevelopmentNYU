using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed = 5f;
	public float health = 10f;
	public static bool isPlayerAlive = true;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0f, -90f * Time.deltaTime, 0f);
		}
		if (Input.GetKey (KeyCode.A)) {
			// when you hardcode a constant value, we call that a "magic number"
			transform.Rotate (0f, 90f * Time.deltaTime, 0f);
		}

		if (health < 0f) {
			Destroy (gameObject);
			isPlayerAlive = false;
		}

		Debug.Log ("Player health: " + health);
	}
}
