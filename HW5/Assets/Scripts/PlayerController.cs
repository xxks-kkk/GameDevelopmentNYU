using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
		float speed = 20f;
		Rigidbody rbody;
		float distToGround;
		Slider healthBarSlider;
		GameObject GM;

		// Use this for initialization
		void Start ()
		{
				rbody = GetComponent<Rigidbody> ();

				// get the distance to ground
				distToGround = collider.bounds.extents.y;
		
				GameObject tmp = GameObject.Find ("HealthBarSlider");
				healthBarSlider = tmp.GetComponent<Slider> ();

				GM = GameObject.Find ("GameManager");
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerStay (Collider other)
		{
				if (other.gameObject.tag == "hazard" && healthBarSlider.value > 0) {
						healthBarSlider.value -= 0.1f;
						GM.GetComponent<GameManager> ().health -= 3f * Time.deltaTime;
				}
		}

		void FixedUpdate ()
		{
				rbody.AddForce (transform.forward * speed * Input.GetAxis ("Vertical"));
				rbody.AddForce (transform.right * speed * Input.GetAxis ("Horizontal"));
				
				if (Input.GetKey (KeyCode.LeftShift)) {
						speed = 30f;
				} else {
						speed = 20f;
				}
				if (Input.GetKeyDown (KeyCode.Space) && isGrounded ()) {
						rbody.AddForce (transform.up * 10, ForceMode.Impulse);
				}
		}
		
		bool isGrounded ()
		{
				return Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.1f);
		}

		void OnCollisionEnter (Collision other)
		{
				if (other.gameObject.tag == "powerup") {
						Destroy (other.gameObject);
						GameObject tmp2 = GameObject.Find ("PowerBarSlider");
						tmp2.GetComponent<Slider> ().value += 5f;
				} else if (other.gameObject.tag == "healup") {
						Destroy (other.gameObject);
						GameObject tmp3 = GameObject.Find ("HealthBarSlider");
						tmp3.GetComponent<Slider> ().value += 5f;
				}
		}
		
}
