using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour {
	public float speed = 4.0f;
	Rigidbody2D rb2D;

	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float translationHorizontal = Input.GetAxis("horizontal") * speed * Time.deltaTime;
		float translationVertical = Input.GetAxis("vertical") * speed * Time.deltaTime;

		rb2D.MovePosition(rb2D.position + new Vector2(translationHorizontal, translationVertical));
	}

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("Collision");
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("endzone") == true) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
