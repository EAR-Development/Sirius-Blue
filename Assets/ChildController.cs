using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildController : MonoBehaviour {

	public bool directionIsLeft = true;

	public bool motherSeen = false;
	public GameObject mother;
	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (motherSeen) {
			float movement = 0;
			if (!directionIsLeft && transform.position.x < mother.transform.position.x) {
				movement = speed;
			}
			if (directionIsLeft && transform.position.x > mother.transform.position.x) {
				movement = -speed;
			}
			transform.position = new Vector3 (transform.position.x + movement, transform.position.y, transform.position.z);
		}
	}
}
