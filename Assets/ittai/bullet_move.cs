using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move : MonoBehaviour {

    public Rigidbody2D rb2d;
    Rigidbody2D gun;
	// Use this for initialization
	void Start () {
        rb2d.GetComponent<Rigidbody2D>();
        gun = GameObject.FindGameObjectWithTag("GUN").GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//        rb2d.MovePosition(new Vector2(rb2d.position.x + 3 *gun.transform.up* Time.fixedDeltaTime, rb2d.position.y + 3  * Time.fixedDeltaTime));
	}
}
