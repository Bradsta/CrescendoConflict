using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour {

    Rigidbody2D player;
    Rigidbody2D gun;

    public Vector2 velocity;

    // Use this for initialization
    void Start() {
        player = gameObject.GetComponent<Rigidbody2D>();
        gun = gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();
    }


    public void move(float directionx,float directiony)
    {
        player.MovePosition(new Vector2(player.position.x + velocity.x * directionx * Time.fixedDeltaTime, player.position.y + velocity.y *directiony * Time.fixedDeltaTime));
        gun.MovePosition(new Vector2(gun.position.x + velocity.x * directionx * Time.fixedDeltaTime, gun.position.y + velocity.y * directiony * Time.fixedDeltaTime));
    }

    public void Rotate(int rotate_speed)
    {
        gun.GetComponent<Rigidbody2D>().MoveRotation(gun.GetComponent<Rigidbody2D>().rotation+ rotate_speed);
       // gun.GetComponent<Rigidbody2D>().
    }
 
}

