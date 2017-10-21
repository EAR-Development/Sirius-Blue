using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[Header("Player Spawn")]
	public GameObject playerPrefab;
	GameObject spawnPoint;
	GameObject player;

	[Header("Camera Boundaries")]
	public float xMinimumPosition;
	public float xMaximumPosition;
	public float yMinimumPosition;
	public float yMaximumPosition;

	[Header("Movement")]
	public float speed = 4.0f;

	Camera cam;
	Gradient g;

	// Use this for initialization
	void Start () {
		spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
		player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

		cam = GetComponent<Camera>();
		cam.clearFlags = CameraClearFlags.SolidColor;

		GradientColorKey[] gck;
		GradientAlphaKey[] gak;
		g = new Gradient();
		gck = new GradientColorKey[2];
		gck[0].color = new Color32( 0x00, 0x00, 0x46, 0xFF );
		gck[0].time = 0.0F;
		gck[1].color = new Color32( 0x1C, 0xB5, 0xE0, 0xFF );
		gck[1].time = 1.0F;
		gak = new GradientAlphaKey[2];
		gak[0].alpha = 1.0F;
		gak[0].time = 0.0F;
		gak[1].alpha = 1.0F;
		gak[1].time = 1.0F;
		g.SetKeys(gck, gak);
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;

		float targetXPosition = Mathf.Min (Mathf.Max (player.transform.position.x, xMinimumPosition), xMaximumPosition);
		float targetYPosition = Mathf.Min (Mathf.Max (player.transform.position.y, yMinimumPosition), yMaximumPosition);


		Vector3 targetPosition = new Vector3 (targetXPosition, targetYPosition, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);


		// BACKGROUND COLOR
		// /////
		float heightRatio = (transform.position.y - yMinimumPosition) / (yMaximumPosition - yMinimumPosition);
		cam.backgroundColor = g.Evaluate(heightRatio);

	}
}
