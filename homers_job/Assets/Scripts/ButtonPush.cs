using UnityEngine;

public class ButtonPush : MonoBehaviour {

    public bool isLit;
    public bool isBlinking;
    public bool isPressed;
    public bool isEnabled;
    public Animator Anim;
	void start() {
        Anim = GetComponent<Animator>();
        isLit = false;
        isBlinking = false;
        isPressed = false;
	}

    // When the Script is enabled
   
    void Update () {
        if (isPressed == true) {
            Anim.SetTrigger("isPushed");
            Debug.Log("Button was pressed");
            isEnabled = !isEnabled;
            Debug.Log("Button toggled");
            isPressed = false;
        }
        if (isEnabled == true) {
            isLit = true;
            Anim.SetBool("isLit", true);
        }
        else {
            isLit = false;
            Anim.SetBool("isLit", false);
        }
    }    
}