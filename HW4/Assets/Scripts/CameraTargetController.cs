using UnityEngine;
using System.Collections;

public class CameraTargetController : MonoBehaviour
{

		void Update ()
		{
				transform.position -= Vector3.up * 2f * Time.deltaTime;
		}
}
