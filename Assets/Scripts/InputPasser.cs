﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPasser : MonoBehaviour {

    public string playerHorz; //for when we add second player, so like Horizontal2, to get the axis for the second player
    public string playerVert;

    private int rotate_speed = 10;

    // Use this for initialization
    void Start () {
      //  player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        gameObject.GetComponent<Player>().move(Input.GetAxisRaw(playerHorz), Input.GetAxisRaw(playerVert));

        Vector2 v = new Vector2(Input.GetAxisRaw("rotationx"), Input.GetAxisRaw("rotationy"));

        if (v != Vector2.zero)
        {
            float angle = Vector2.Angle(Vector2.up, v);

            if (v.x > 0)
            {
                angle *= -1;
            }

            gameObject.GetComponent<Player>().RotateStick(angle);
        }

        if (Input.GetKey("o")) 
            gameObject.GetComponent<Player>().Rotate(rotate_speed);
        if(Input.GetKey("p"))
            gameObject.GetComponent<Player>().Rotate(rotate_speed*-1);
        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.GetComponent<Player>().Shoot();
        }

        //print(Input.GetAxis("rotationx")+","+Input.GetAxis("rotationy"));

    }
}
