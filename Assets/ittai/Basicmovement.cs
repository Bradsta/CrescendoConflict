using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basicmovement : MonoBehaviour {

    Rigidbody2D player;
    public Vector2 velocity;
    public float rotate_speed;
    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (Input.GetButton("Horizontal")|| Input.GetButton("Vertical"))
        {

            player.MovePosition(new Vector2(player.position.x + velocity.x *Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime,
                                    player.position.y + velocity.y * Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime));

        }

        if (Input.GetKey("o"))
        {
            player.MoveRotation(player.rotation+rotate_speed*Time.deltaTime);
        }
    }
}
