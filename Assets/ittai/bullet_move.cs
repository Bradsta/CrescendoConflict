using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move : MonoBehaviour {

    public Rigidbody2D rb2d;
    Rigidbody2D gun;
    Vector2 gundirection;
    
    // Use this for initialization
    void Start () {
        rb2d.GetComponent<Rigidbody2D>();
        gun = GameObject.FindGameObjectWithTag("GUN").GetComponent<Rigidbody2D>();
        //Vector2 gundirection = gun.transform.right;
        //rb2d.transform.Translate(gundirection *Time.deltaTime);

    }

    // Update is called once per frame
    void FixedUpdate () {
        rb2d.transform.position += rb2d.transform.right * Time.deltaTime * 3;
	}
}
