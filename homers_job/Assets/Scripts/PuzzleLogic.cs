using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleLogic : MonoBehaviour {

	public GameObject[] Buttons;
	public int[] puzzle_start;
	public int[] puzzle_current;
	public int[] puzzle_last;
	public int[] puzzle_solution;
	public int solution_btn_count;
	public int tries;
	public bool win;
	GameObject Lamppu1;
	GameObject Lamppu2;
	GameObject Lamppu3;

	// Use this for initialization
	void Start () {
		Lamppu1 = GameObject.FindGameObjectWithTag("lamppu_1");
		Lamppu2 = GameObject.FindGameObjectWithTag("lamppu_2");
		Lamppu3 = GameObject.FindGameObjectWithTag("lamppu_3");
		win = false;
		tries = 0;
		solution_btn_count  = 0;
		puzzle_start = new int[8];
		puzzle_current = new int[8];
		puzzle_last = new int[8];
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
		if (puzzle_start[0] == 0 && puzzle_start[1] == 0 && puzzle_start[2] == 0) {
			puzzle_start[1] = 1;
			puzzle_current[1] = 1;
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
		puzzle_last = puzzle_current;
		for (int i = 0; i < Buttons.Length; i++) {
			if (Buttons[i].GetComponent<ButtonPush>().isEnabled == true) {
				puzzle_current[i] = 1;
			}
			else {
				puzzle_current[i] = 0;
			}
		}
		for (int i = 0; i < puzzle_current.Length; i++) {
			if (puzzle_last[i] != puzzle_current[i]) {
				if (puzzle_current[i] != puzzle_solution[i]) {
					tries++;
				}
			}
		}
		if (tries >= 1) {
			Lamppu1.GetComponent<Animator>().SetBool("isLit", true);
			if (tries >= 2) {
				Lamppu2.GetComponent<Animator>().SetBool("isLit", true);
				if (tries >= 3) {
					Lamppu3.GetComponent<Animator>().SetBool("isLit", true);
				}
			}
		}
		if (tries >= 3) {
			win = false;
		}
		if (win == false) {
			if (Enumerable.SequenceEqual(puzzle_current, puzzle_solution)) {
				Debug.Log("you win!");
				win = true;
			}
		}
	}
}
