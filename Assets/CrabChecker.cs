using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabChecker : MonoBehaviour {

	public bool isOverRubish;
	public bool isOverGround;
	public bool isOverShell;
	public GameObject shell;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("rubish")) {
			isOverRubish = true;
		}
		if (other.CompareTag ("ground")) {
			isOverGround = true;
		}
		if (other.CompareTag ("shell")) {
			isOverShell = true;
			shell = other.gameObject; 
		}
	}
		
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("rubish")) {
			isOverRubish = true;
		}
		if (other.CompareTag ("ground")) {
			isOverGround = true;
		}
		if (other.CompareTag ("shell")) {
			isOverShell = true;
			shell = other.gameObject; 
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("rubish")) {
			isOverRubish = false;
		}
		if (other.CompareTag ("ground")) {
			isOverGround = false;
		}
		if (other.CompareTag ("shell")) {
			isOverShell = false;
			shell = null; 
		}
	}
}
