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
	GameObject puzzle;

	void checkinteraction() {
		Vector3 origin = cam.transform.position;
		Vector3 direction = cam.transform.forward;
		float distance = 10f;
		RaycastHit hit;
		messagetext.text = "";
		if (Physics.Raycast(origin, direction, out hit, distance)) {
			Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 4f, Color.white);
			 if (hit.transform.tag == "button") {
				 messagetext.text = "Press E to interact";
				 Debug.Log("Ray hit button");
				 if (Input.GetKeyDown(KeyCode.E)) {
					 //hit.transform.gameObject.GetComponent<Animator>().SetTrigger("isPushed");
					 hit.transform.gameObject.GetComponent<ButtonPush>().isPressed = true;
				 }
			 }
		}
		if (puzzle.GetComponent<PuzzleLogic>().win == true) {
			messagetext.text = "You Win!";
		}
		if (puzzle.GetComponent<PuzzleLogic>().tries >= 3) {
			messagetext.text = "You lost.";
		}
	}
	void Start () {
		puzzle = GameObject.FindGameObjectWithTag("puzzle");
		messagetext = GameObject.Find("Canvas/Text").GetComponent<Text>();
		offset = cam.transform.position - Player.transform.position;
		Cursor.lockState = CursorLockMode.Locked;
		if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P)) {
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
