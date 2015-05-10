using UnityEngine;
using System.Collections;

// spawn the pursuer enemy
public class PursuerSpawner : MonoBehaviour
{
	public Transform enemy;
	public Transform player;
	float Timer;

	void Awake ()
	{
		Timer = Time.time + 3;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Timer < Time.time) {//This checks wether real time has caught up to the timer
			//Vector3 v3Pos = Camera.main.ScreenToWorldPoint (new Vector3 (player.transform.position.x + 40f, player.transform.position.y + 40f, Camera.main.nearClipPlane));
			Vector3 v3Pos = new Vector3 (player.transform.position.x + 6f, player.transform.position.y, player.transform.position.z + 4f);
			Instantiate (enemy, v3Pos, Quaternion.identity);
			Timer = Time.time + 3; //This sets the timer 3 seconds into the future
		}

	}
}
