using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	Text messagetext;

	void checkinteraction() {
		Vector3 origin = cam.transform.position;
		Vector3 direction = cam.transform.forward;
		float distance = 4f;
		RaycastHit hit;
		messagetext.text = "";
		if (Physics.Raycast(origin, direction, out hit, distance)) {
			 if (hit.transform.tag == "button") {
				 messagetext.text = "Press E to interact";
				 if (Input.GetKeyDown(KeyCode.E)) {
					 hit.transform.gameObject.GetComponent<ButtonPush>().enabled = true;
				 }
			 }
		}
	}
	void Start () {
		messagetext = GameObject.Find("Canvas/Text").GetComponent<Text>();
		cam = Camera.main;
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
		checkinteraction();
	}
}
