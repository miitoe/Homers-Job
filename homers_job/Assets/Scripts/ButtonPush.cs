using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour {

    float startTime;
    bool isPushed = false;
	float Zaxis;
	float minZ = -0.7f;
	float maxZ = 0f;

	void start() {
	}

    // When the Script is enabled
    void OnEnable () {
        //If isOpened == true, then set it to false and vice-versa
        isPushed = !isPushed;

        startTime = Time.time;
    }

    void Update () {

        //If the door was open...
        if (isPushed)
        {
            //...start closing it at a rate of -90 degrees per second
            transform.position += new Vector3(0, -0.7f, 0) * Time.deltaTime;
        } 
        else
        {
            //...otherwise open it at a rate of 90 degrees per second
            transform.position += new Vector3(0, 0.7f, 0) * Time.deltaTime;
        }


        //If it has been 1 second since we started
        if (Time.time - startTime > 0.1f)
        {
            //De-enable the script
            enabled = false;
        }
		Mathf.Clamp(transform.forward.y, minZ, maxZ);
    }
}