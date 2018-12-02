using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleLogic : MonoBehaviour {

	public GameObject[] Buttons;
	public int[] puzzle_start;
	public int[] puzzle_current;
	public int[] puzzle_solution;
	public int solution_btn_count;

	// Use this for initialization
	void Start () {
		solution_btn_count  = 0;
		puzzle_start = new int[8];
		puzzle_current = new int[8];
		puzzle_solution = new int[8];
		Buttons = GameObject.FindGameObjectsWithTag("button"); //create array of button gameobjects
		Buttons = Buttons.OrderBy( gameObject => gameObject.name).ToArray<GameObject>();
		for (int i = 0; i < Buttons.Length; i++) { //initialize array
			if (Random.Range(0, 2) == 1) {
				Debug.Log("button should be enabled");
				Buttons[i].GetComponent<ButtonPush>().isEnabled = true;
				Debug.Log("toimii");
				puzzle_current[i] = 1;
				puzzle_start[i] = 1;
				solution_btn_count += (int)Mathf.Pow(2, 1.0f * i);
			}
			else {
				Buttons[i].GetComponent<ButtonPush>().isEnabled = false;
				puzzle_current[i] = 0;
				puzzle_start[i] = 0;
			}
		}
		solution_btn_count = solution_btn_count % 8;
		for (int i = 0; i < puzzle_start.Length; i++) {
			if (puzzle_start[i] == 1){
				if (i + solution_btn_count < 8) {
					if (puzzle_solution[i+solution_btn_count] == 0) {
					puzzle_solution[i+solution_btn_count] = 1;
					}
				}
				else {
					if (puzzle_solution[i+solution_btn_count-8] == 0) {
					puzzle_solution[i+solution_btn_count-8] = 1;
					}
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Buttons.Length; i++) {
			if (Buttons[i].GetComponent<ButtonPush>().isEnabled == true) {
				puzzle_current[i] = 1;
			}
			else {
				puzzle_current[i] = 0;
			}
		}
		if (Enumerable.SequenceEqual(puzzle_current, puzzle_solution)) {
			Debug.Log("you win!");
		}
	}
}
