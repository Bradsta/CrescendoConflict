using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputPasser : MonoBehaviour {

    //Rigidbody2D player;
    //public Vector2 velocity;
    public float rotate_speed;

    public string moveUp;
    public string moveDown;
    public string moveLeft;
    public string moveRight;
    // Use this for initialization
    void Start () {
      //  player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(moveUp))
        {
            gameObject.GetComponent<inputHandler>().moveVert(1);
        }
        if (Input.GetKey(moveDown))
        {
            gameObject.GetComponent<inputHandler>().moveVert(-1);
        }
        if (Input.GetKey(moveLeft))
        {
            gameObject.GetComponent<inputHandler>().moveHorz(-1);
        }
        if (Input.GetKey(moveRight))
        {
            gameObject.GetComponent<inputHandler>().moveHorz(1);
        }



    }
}
