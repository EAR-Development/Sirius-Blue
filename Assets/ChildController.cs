using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildController : MonoBehaviour {

	public bool directionIsLeft = true;

	public bool motherSeen = false;
	public GameObject mother;
	public float speed = 5.0f;

	float randomOffset;

	// Use this for initialization
	void Start () {
		randomOffset = Random.Range (-1, 1) * 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (motherSeen) {
			float movement = 0;
			float hspeed = 0;
			if (!directionIsLeft && transform.position.x < (mother.transform.position.x + randomOffset)) {
				movement = speed * (Mathf.Abs(transform.position.x - mother.transform.position.x )+1) * Time.deltaTime;
			}
			if (directionIsLeft && transform.position.x > (mother.transform.position.x + randomOffset)) {
				movement = -speed * (Mathf.Abs(transform.position.x - mother.transform.position.x)+1) * Time.deltaTime;
			}

			if (Mathf.Abs(transform.position.x - (mother.transform.position.x + randomOffset)) < 0.1) {
				Vector3 rot = transform.eulerAngles;
				rot.z = 180;
				transform.eulerAngles = rot;
				hspeed = (mother.transform.position.y - transform.position.y) * speed * Time.deltaTime;
			}

			transform.position = new Vector3 (transform.position.x + movement, transform.position.y + hspeed, transform.position.z);
		}
	}
}
