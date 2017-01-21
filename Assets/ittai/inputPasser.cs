using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputPasser : MonoBehaviour {

    public int rotate_speed;
    public string playerHorz; //for when we add second player, so like Horizontal2, to get the axis for the second player
    public string playerVert;
    // Use this for initialization
    void Start () {
      //  player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        gameObject.GetComponent<inputHandler>().move(Input.GetAxisRaw(playerHorz), Input.GetAxisRaw(playerVert));
        if (Input.GetKey("o")) 
            gameObject.GetComponent<inputHandler>().Rotate(rotate_speed);
        if(Input.GetKey("p"))
            gameObject.GetComponent<inputHandler>().Rotate(rotate_speed*-1);


    }
}
