using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubishController : MonoBehaviour {

	float lifeTimer = 0.1f;
	public bool markedToKill = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (markedToKill){
			lifeTimer -= Time.deltaTime;
			if (lifeTimer <= 0) {
				GameObject.Destroy (this.gameObject);
			}
		}
	}

	public void markAsDead(){
		markedToKill = true;
		GetComponent<BoxCollider2D> ().offset.Set (-1000, -1000);
	}
}
