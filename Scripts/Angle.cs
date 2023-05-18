using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : MonoBehaviour
{
public Vector2 point;
    public float angles;
    public Vector2 pos;
    float anglesConfig;

    string PlayerNumName;

    public GameObject eje;
    public Vector3 mira;
    public GameObject m;

    public GameObject p;
    public GameObject vista;
    float speed = 10f;



    float x;
    float y;
  

    public float lookMouse;

    void Start() {
        PlayerNumName = transform.name;
        eje.transform.rotation = Quaternion.Euler(0, 0, 180f);
    }

    
    void Update() {
        if (!JoystickInput.isPc) {
        pos = transform.position;
        point.x = Input.GetAxis(PlayerNumName + "_X");
        point.y = Input.GetAxis(PlayerNumName + "_Y") * -1f;
        //point.x = Input.GetAxis(PlayerNumName + "_X");
        //point.y = Input.GetAxis(PlayerNumName + "_Y") * -1f;

        vista.transform.position = pos + (point*8);

        if(point.x  != 0) {        
            x = point.x;
        }
        if (point.y != 0) {       
            y = point.y;
        }       
        mira = (new Vector2(x, y) * 4) + pos;
        if (Vector2.Distance(mira, pos) > 0.5f/* point != Vector2.zero*/ ) {

            angles = AnguloEntreVectores(mira, pos);
            anglesConfig = ((mira.y < pos.y) ? 1.0f * angles : -1.0f * angles) + 180;

            Quaternion rotZ = Quaternion.Euler(0, 0, anglesConfig);
            eje.transform.rotation = rotZ;
            
        }

        if (point != Vector2.zero) {
            p.transform.position = Vector3.Lerp(p.transform.position, vista.transform.position, Time.deltaTime * speed);
        }
        else {
            p.transform.position = Vector3.Lerp(p.transform.position, m.transform.position, Time.deltaTime * speed);
        }

        lookMouse = LookMouse(p.transform.position, pos);
        }
        else {

            pos = transform.position;
           
                angles = AnguloEntreVectores(Input.mousePosition, pos);
                anglesConfig = ((Input.mousePosition.y < pos.y) ? 1.0f * angles : -1.0f * angles) + 180;

                Quaternion rotZ = Quaternion.Euler(0, 0, anglesConfig);
                eje.transform.rotation = rotZ;

                p.transform.position = Input.mousePosition;
            

            lookMouse = LookMouse(p.transform.position, pos);
        }   
    }

    public float AnguloEntreVectores(Vector2 vec1, Vector2 vec2) {

        
        Vector2 dif = vec2 - vec1;
        float angulo =  Vector2.Angle(Vector2.right, dif);
        //float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        //return angulo * sign;
        return angulo;
    }

    public float LookMouse(Vector3 posMouse, Vector2 pos) {

        float n = 0;
        
        if (angles < 22.5 ) {

           n = 1; // L
        }
        else if (angles > 22.5 && angles < 67.5 && posMouse.y <= pos.y) {

           n = 2; // DL
        }
        else if (angles > 67.5 && angles < 112.5 && posMouse.y <= pos.y) {

            n = 3; // D

        }
        else if (angles > 112.5 && angles < 157.5 && posMouse.y <= pos.y) {

           n = 4; //  DR

        }
        else if (angles > 157.5) {

           n = 5; //  R

        }
        else if (angles > 112.5 && angles < 157.5 && posMouse.y > pos.y) {

            n = 6; // UR

        }
        else if (angles > 67.5 && angles < 112.5 && posMouse.y > pos.y) {

           n = 7; // U

        }
        else if (angles > 22.5 && angles < 67.5 && posMouse.y > pos.y) {

           n = 8; // UL

        }
       


        return n;

    }
}
