using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour {
	public float speed = 4.0f;
	public float magicCooldown = 2.0f;

	float cooldownTimer = 100.0f;

	public GameObject magicballPrefab;
	public GameObject wand;
	public CameraController mainCamera;

	Rigidbody2D rb2D;

	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// Movement
		float translationHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float translationVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		rb2D.MovePosition(rb2D.position + new Vector2(translationHorizontal, translationVertical));

		Vector3 rot = transform.eulerAngles;

		float rotationoffset = -90;

		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		if (translationHorizontal > 0 && translationVertical > 0) {
			rot.z = -45 + rotationoffset;
			renderer.flipY = true;
		}
		if (translationHorizontal > 0 && translationVertical < 0) {
			rot.z = -135 + rotationoffset;
			renderer.flipY = true;
		}
		if (translationHorizontal > 0 && translationVertical == 0) {
			rot.z = -90 + rotationoffset;
			renderer.flipY = true;
		}
		if (translationHorizontal < 0 && translationVertical > 0) {
			rot.z = 45 + rotationoffset;
			renderer.flipY = false;
		}
		if (translationHorizontal < 0 && translationVertical < 0) {
			rot.z = 135 + rotationoffset;
			renderer.flipY = false;
		}
		if (translationHorizontal < 0 && translationVertical == 0) {
			rot.z = 90 + rotationoffset;
			renderer.flipY = false;
		}
		if (translationHorizontal == 0 && translationVertical > 0) {
			rot.z = 0 + rotationoffset;
			renderer.flipY = true;
		}
		if (translationHorizontal == 0 && translationVertical < 0) {
			rot.z = 180 + rotationoffset;
			renderer.flipY = true;
		}
		transform.eulerAngles = rot;



		// Magic
		if(Input.GetAxis("Jump") > 0 && cooldownTimer > magicCooldown){
			cooldownTimer = 0;
			Instantiate(magicballPrefab, wand.transform.position, wand.transform.rotation);
		}

		cooldownTimer += Time.deltaTime;

	}

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("Collision");
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("endzone") == true) {
			mainCamera.ShowEndScreen (true);
		}
	}
}
