using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MonoBehaviour {

	public GameObject leftFreeCheck;
	public GameObject rightFreeCheck;

	public GameObject leftFloorCheck;
	public GameObject rightFloorCheck;

	public GameObject shell;

	public bool directionIsLeft = true;

	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float movement = 0;

		if (!directionIsLeft && ! rightFreeCheck.GetComponent<CrabChecker>().isOverRubish 
			&& ! rightFreeCheck.GetComponent<CrabChecker>().isOverGround 
			&& rightFloorCheck.GetComponent<CrabChecker>().isOverGround) {
			movement = speed;
		}
		if (directionIsLeft && ! leftFreeCheck.GetComponent<CrabChecker>().isOverRubish 
			&& ! leftFreeCheck.GetComponent<CrabChecker>().isOverGround 
			&& leftFloorCheck.GetComponent<CrabChecker>().isOverGround) {
			movement = -speed;
		}


		if (!directionIsLeft && rightFreeCheck.GetComponent<CrabChecker>().isOverShell) {
			GameObject.Destroy (rightFreeCheck.GetComponent<CrabChecker>().shell);
			shell.SetActive (true);
			directionIsLeft = true;
		}
		if (directionIsLeft && leftFreeCheck.GetComponent<CrabChecker>().isOverShell) {
			GameObject.Destroy (leftFreeCheck.GetComponent<CrabChecker>().shell);
			shell.SetActive (true);
			directionIsLeft = false;
		}


		transform.position = new Vector3 (transform.position.x + movement, transform.position.y, transform.position.z);
	}
}
