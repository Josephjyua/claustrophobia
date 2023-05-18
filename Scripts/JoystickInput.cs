using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour {

    public static bool isPc = false;

    public bool lb,lt,rb,rt,a,b,x,y,botton6,botton7,botton8,botton9, up , down , left , right = false;

    public bool rbDown, rbUp = false;
 

    void Start () {
		
	}
	
	
	void Update () {

        switch (transform.name) {

            case "P1":
                InputSetting(transform.name);     
                break;
            case "P2":
                InputSetting(transform.name);
                break;
            case "P3":
                InputSetting(transform.name);
                break;
            case "P4":
                InputSetting(transform.name);
                break;

        }
        
	}

    void AxisPad(string n) {

        if (isPc) {
            if (Input.GetAxis("Horizontal") == -1f) { left = true; right = false; }
            if (Input.GetAxis("Horizontal") == 1f) { left = false; right = true; }
            if (Input.GetAxis("Horizontal") == 0f) { left = false; right = false; }

            if (Input.GetAxis("Vertical") == -1f) { down = true; up = false; }
            if (Input.GetAxis("Vertical") == 1f) { down = false; up = true; }
            if (Input.GetAxis("Vertical") == 0f) { down = false; up = false; }

        }
        else {

            if (Input.GetAxis(n + "_XPAD") == -1f) { left = true; right = false; }
            if (Input.GetAxis(n + "_XPAD") == 1f) { left = false; right = true; }
            if (Input.GetAxis(n + "_XPAD") == 0f) { left = false; right = false; }

            if (Input.GetAxis(n + "_YPAD") == -1f) { down = true; up = false; }
            if (Input.GetAxis(n + "_YPAD") == 1f) { down = false; up = true; }
            if (Input.GetAxis(n + "_YPAD") == 0f) { down = false; up = false; }
        }

     
        
    }

    void InputSetting(string n) {
        if (!isPc) {
            rbDown = Input.GetKeyDown(KeyCode.Joystick1Button5);
            rbUp = Input.GetKeyUp(KeyCode.Joystick1Button5);

            if (Input.GetKeyDown(KeyCode.Joystick1Button0)) { a = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button0)) { a = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button1)) { b = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button1)) { b = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button2)) { x = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button2)) { x = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button3)) { y = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button3)) { y = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button4)) { lb = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button4)) { lb = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button5)) { rb = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button5)) { rb = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button6)) { botton6 = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button6)) { botton6 = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button7)) { botton7 = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button7)) { botton7 = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button8)) { botton8 = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button8)) { botton8 = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button9)) { botton9 = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button9)) { botton9 = false; }

            if (Input.GetAxis(n + "_RT") != 0) { rt = true; } else { rt = false; }
            if (Input.GetAxis(n + "_LT") != 0) { lt = true; } else { lt = false; }
        }
        else {
            rbDown = Input.GetKeyDown(KeyCode.Mouse1);
            rbUp = Input.GetKeyUp(KeyCode.Mouse1);

            if (Input.GetKeyDown(KeyCode.KeypadEnter)) { a = true; }
            if (Input.GetKeyUp(KeyCode.KeypadEnter)) { a = false; }

            if (Input.GetKeyDown(KeyCode.B)) { b = true; }
            if (Input.GetKeyUp(KeyCode.B)) { b = false; }

            if (Input.GetKeyDown(KeyCode.I)) { x = true; }
            if (Input.GetKeyUp(KeyCode.I)) { x = false; }

            if (Input.GetKeyDown(KeyCode.U)) { y = true; }
            if (Input.GetKeyUp(KeyCode.U)) { y = false; }

            if (Input.GetKeyDown(KeyCode.Q)) { lb = true; }
            if (Input.GetKeyUp(KeyCode.Q)) { lb = false; }

            if (Input.GetKeyDown(KeyCode.Joystick1Button5)) { rb = true; }
            if (Input.GetKeyUp(KeyCode.Joystick1Button5)) { rb = false; }

            if (Input.GetKeyDown(KeyCode.Y)) { botton6 = true; }
            if (Input.GetKeyUp(KeyCode.Y)) { botton6 = false; }

            if (Input.GetKeyDown(KeyCode.T)) { botton7 = true; }
            if (Input.GetKeyUp(KeyCode.T)) { botton7 = false; }

            if (Input.GetKeyDown(KeyCode.R)) { botton8 = true; }
            if (Input.GetKeyUp(KeyCode.R)) { botton8 = false; }

            if (Input.GetKeyDown(KeyCode.P)) { botton9 = true; }
            if (Input.GetKeyUp(KeyCode.P)) { botton9 = false; }

            if (Input.GetKeyDown(KeyCode.Mouse0)) { rt = true; }
            if (Input.GetKeyUp(KeyCode.Mouse0)) { rt = false; }

            if (Input.GetKeyDown(KeyCode.E)) { lt = true; }
            if (Input.GetKeyUp(KeyCode.E)) { lt = false; }


        }


        AxisPad(n);

    }
}



