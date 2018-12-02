using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour {

    public Animator anim;
    public bool isPushed = false;

	void start() {
        anim = GetComponent<Animator>();
	}

    // When the Script is enabled
   
    void Update () {
        if (isPushed == true) {
            Debug.Log("Button was pushed");
            anim.SetTrigger("isPushed");
            isPushed = false;
        }
    }
}