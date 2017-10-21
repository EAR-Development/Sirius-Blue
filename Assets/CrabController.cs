using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MonoBehaviour {

	public GameObject leftFreeCheck;
	public GameObject rightFreeCheck;

	public bool directionIsLeft = true;

	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float movement = 0;

		if (!directionIsLeft && ! rightFreeCheck.GetComponent<CrabChecker>().isOverRubish) {
			movement = speed;
		}
		if (directionIsLeft && ! leftFreeCheck.GetComponent<CrabChecker>().isOverRubish) {
			movement = -speed;
		}


		if (!directionIsLeft && rightFreeCheck.GetComponent<CrabChecker>().isOverShell) {
			GameObject.Destroy (rightFreeCheck.GetComponent<CrabChecker>().shell);
			GameObject.Destroy (this.gameObject);
		}
		if (directionIsLeft && leftFreeCheck.GetComponent<CrabChecker>().isOverShell) {
			GameObject.Destroy (leftFreeCheck.GetComponent<CrabChecker>().shell);
			GameObject.Destroy (this.gameObject);
		}


		transform.position = new Vector3 (transform.position.x + movement, transform.position.y, transform.position.z);
	}
}
