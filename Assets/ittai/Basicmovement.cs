using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basicmovement : MonoBehaviour {

    Rigidbody2D player;
    public Vector2 velocity;
    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButton("Horizontal"))
        {
            player.MovePosition( new Vector2 movement=Vector2( player.position + velocity.x* Input.GetAxis("Horizontal")* Time.fixedDeltaTime));

        }

        if (Input.GetButton("Vertical"))
        {
            player.MovePosition(player.positio+ velocity.y* Input.GetAxis("Vertical") * Time.fixedDeltaTime);

        }

    }
}
