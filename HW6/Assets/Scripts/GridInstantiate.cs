using UnityEngine;
using System.Collections;

// put this on a small cube, it will instantiate a grid of 5x5 floors with random walls
public class GridInstantiate : MonoBehaviour
{
		public Transform floorPrefab;
		public Transform wallPrefab;
		float rand;

		// Use this for initialization
		void Start ()
		{
				for (int x = 0; x < 5; x++) {
						for (int z = 0; z<5; z++) {
								Vector3 pos = new Vector3 (x * 0.5f, 0, z * 0.5f) + transform.position;
								rand = Random.Range (0f, 1f);
								//Debug.Log ("Pos: " + pos);
								//Debug.Log ("Cur pos: " + transform.position);
								//Debug.Log ("rand: " + rand);
								if (rand <= 0.7f) {
										Instantiate (floorPrefab, pos, Quaternion.identity);
								} else if (rand < 0.95f) {
										Instantiate (wallPrefab, pos, Quaternion.identity);
								} else {

								}
						}
				}
				Destroy (gameObject);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
