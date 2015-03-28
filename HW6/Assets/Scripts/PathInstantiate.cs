using UnityEngine;
using System.Collections;


public class PathInstantiate : MonoBehaviour
{

		int counter = 0;
		public Transform floorTilePrefab;
		float rand, rand2;
		public float chance;
		public Transform GridInstantiateCube;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (counter < 50) {
						rand = Random.Range (0f, 1f);
						if (rand < 0.25f) {
								transform.Rotate (0f, 90f, 0f);
						} else if (rand < 0.5f) {
								transform.Rotate (0f, -90f, 0f);
						}
						Instantiate (floorTilePrefab, transform.position, Quaternion.identity);
						
						
						
						transform.position += transform.forward * 5f;
						counter += 1;
				} else {
						Destroy (gameObject);
				}

				rand2 = Random.Range (0f, 1f);
				if (rand2 < chance) {
						Instantiate (GridInstantiateCube);
				}
		}

		void OnTriggerEnter (Collider other)
		{
				Destroy (other.gameObject);
		}
}
