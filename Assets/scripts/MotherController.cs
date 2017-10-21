using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherController : MonoBehaviour {

	public GameObject bottomFreeCheck;
	public GameObject topFreeCheck; 

	public bool directionIsDown = true;

	public float speed = 0.4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float movement = 0;

		if (!directionIsDown
			&& ! topFreeCheck.GetComponent<CrabChecker>().isOverShell 
			&& ! topFreeCheck.GetComponent<CrabChecker>().isOverRubish 
			&& ! topFreeCheck.GetComponent<CrabChecker>().isOverGround ) {
			movement = speed;
		}
		if (directionIsDown 
			&& ! bottomFreeCheck.GetComponent<CrabChecker>().isOverShell 
			&& ! bottomFreeCheck.GetComponent<CrabChecker>().isOverRubish 
			&& ! bottomFreeCheck.GetComponent<CrabChecker>().isOverGround ) {
			movement = -speed;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y + movement, transform.position.z);
	}
}
