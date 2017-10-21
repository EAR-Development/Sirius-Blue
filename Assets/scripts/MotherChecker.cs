using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherChecker : MonoBehaviour {

	public GameObject Mother;
	public GameObject Child;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == Mother) {
			Child.GetComponent<ChildController> ().motherSeen = true;
			Child.GetComponent<ChildController> ().mother = Mother;
		}
	}
}
