using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputPasser : MonoBehaviour {

    // Use this for initialization
    void Start () {
      //  player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        gameObject.GetComponent<inputHandler>().move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));



    }
}
