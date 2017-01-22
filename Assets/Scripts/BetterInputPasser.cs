using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterInputPasser : MonoBehaviour {

    private int rotate_speed = 10;

    private Player player;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<Player>();
	}

	void FixedUpdate () {
        gameObject.GetComponent<Player>().move(Input.GetAxisRaw("Horizontal_P" + player.playerNum), Input.GetAxisRaw("Vertical_P" + player.playerNum));

        Vector2 v = new Vector2(Input.GetAxisRaw("RotationAxisX_P" + player.playerNum), Input.GetAxisRaw("RotationAxisY_P" + player.playerNum));
        if (v != Vector2.zero)
        {
            float angle = Vector2.Angle(Vector2.up, v);

            if (v.x > 0)
            {
                angle *= -1;
            }

            gameObject.GetComponent<Player>().RotateStick(angle);
        }

        gameObject.GetComponent<Player>().Rotate((int) (rotate_speed * Input.GetAxisRaw("Rotation_P" + player.playerNum)));

        if (Input.GetButtonDown("Fire_P" + player.playerNum))
        {
            gameObject.GetComponent<Player>().Shoot();
        }
    }
}
