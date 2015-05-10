using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Enter the wayPoint");
		if (other.gameObject.tag == "Enemy") {
			Debug.Log ("Enter the WayPoint trigger by enemy");
			if (other.gameObject.GetComponent<EnemyControllerAdv> ().startWalkAroundObstacles) {
				other.gameObject.GetComponent<EnemyControllerAdv> ().getClosetPos = true;
			}
		}
	}
}
