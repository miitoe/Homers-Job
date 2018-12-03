using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
 
 public class Pausemenu : MonoBehaviour {
     bool paused;

     void Start() {
         paused = false;
     }
 
     void Update()  {
         if(Input.GetKey(KeyCode.P)){
             paused = togglePause();
            }
     }
     
     void OnGUI()
     {
         if(paused)
         {
             GUILayout.Label("Game is paused!");
             if(GUILayout.Button("Click me to unpause"))
                 paused = togglePause();
         }
     }
     
     bool togglePause()
     {
         if(Time.timeScale == 0f)
         {
             Time.timeScale = 1f;
             return(false);
         }
         else
         {
             Time.timeScale = 0f;
             return(true);    
         }
     }
 }