using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour {

    Rigidbody2D rb;
    float movX;
    float movY;
    public float velocidad =2;

    public string PlayerNumName;

    bool atacando = false;
    bool dasheando = false;

    void Start () {
       
        rb = GetComponent<Rigidbody2D>();
        PlayerNumName = transform.name;    

    }
		
	void FixedUpdate () {
        atacando = GetComponent<AnimatorController>().atacando;
        dasheando = GetComponent<AnimatorController>().isDasheable;
        Movement(atacando,dasheando);
	}

    void Movement(bool a, bool d) {
        if (!a && !d) {

            movX = Input.GetAxisRaw(PlayerNumName + "_X");
            movY = Input.GetAxisRaw(PlayerNumName + "_Y") * -1f;
            Vector2 mov = new Vector2(movX, movY);
            rb.MovePosition(rb.position + mov.normalized * velocidad * Time.deltaTime);
        }
       
      //  rb.velocity = mov.normalized * velocidad * Time.deltaTime;
    }
}

