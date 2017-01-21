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

    public void moveHorz(int direction)
    {
        player.MovePosition(new Vector2(player.position.x + velocity.x * direction * Time.fixedDeltaTime, player.position.y));
                                 // player.position.y + velocity.y * Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime));
    }
    public void moveVert(int direction)
    {
        player.MovePosition(new Vector2(player.position.x,player.position.y + velocity.y * direction * Time.fixedDeltaTime));//player.position.x + velocity.x * direction * Time.fixedDeltaTime,

    }
}

