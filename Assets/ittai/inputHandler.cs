using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour {

    Rigidbody2D player;
    public Vector2 velocity;

    // Use this for initialization
    void Start() {
        player = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {

    }

    public void move(float directionx,float directiony)
    {
        player.MovePosition(new Vector2(player.position.x + velocity.x * directionx * Time.fixedDeltaTime, player.position.y + velocity.y *directiony * Time.fixedDeltaTime));

    }
  /*  public void moveVert(float direction)
    {
        player.MovePosition(new Vector2(player.position.x,player.position.y + velocity.y * direction * Time.fixedDeltaTime));//player.position.x + velocity.x * direction * Time.fixedDeltaTime,

    }*/
}

