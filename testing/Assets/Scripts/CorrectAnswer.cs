using UnityEngine;
using System.Collections;

public class CorrectAnswer : MonoBehaviour
{
	public float speed = 100f;

	void Update()
	{
		transform.Rotate (Vector3.up, speed * Time.deltaTime,0);
	}
}