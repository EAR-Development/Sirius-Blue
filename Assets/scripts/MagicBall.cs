using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour {

	public float speed = 1.0f;
	Rigidbody2D rb2D;

	void Start() {
		rb2D = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		rb2D.MovePosition(rb2D.position + new Vector2(transform.up.x, transform.up.y) * speed);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("rubish")) {
			other.gameObject.SetActive(false);
		}
		GameObject.Destroy (this.gameObject);
	}
}
