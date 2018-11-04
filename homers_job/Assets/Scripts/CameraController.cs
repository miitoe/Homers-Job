using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public float minX = -60f;
	public float maxX = 60f;
	public float minY = -360f;
	public float MaxY = 360f;
	public float sensitivityX = 15f;
	public float sensitivityY = 15f;
	public Camera cam;
	public GameObject Player;

	float rotationX = 0f;
	float rotationY = 0f;
	private Vector3 offset;
	void Start () {
		offset = cam.transform.position - Player.transform.position;
		Cursor.lockState = CursorLockMode.Locked;
		if (Input.GetKey(KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		rotationY += Input.GetAxis("Mouse X") * sensitivityY;
		rotationX += Input.GetAxis("Mouse Y") * sensitivityX;

		rotationX = Mathf.Clamp(rotationX, minX, maxX);

		transform.localEulerAngles = new Vector3(0, rotationY, 0);
		cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
		cam.transform.position = Player.transform.position + offset;
	}
}
