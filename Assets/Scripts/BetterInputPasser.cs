using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterInputPasser : MonoBehaviour {

    private int rotate_speed = 10;

    private Player player;
    private string playerNum;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<Player>();

        switch (player.PlayerNumber)
        {
            case PlayerNumber.PLAYER_1:
                playerNum = "1";
                break;
            case PlayerNumber.PLAYER_2:
                playerNum = "2";
                break;
        }
	}

	void FixedUpdate () {
        gameObject.GetComponent<Player>().move(Input.GetAxisRaw("Horizontal_P" + playerNum), Input.GetAxisRaw("Vertical_P" + playerNum));

        Vector2 v = new Vector2(Input.GetAxisRaw("RotationAxisX_P" + playerNum), Input.GetAxisRaw("RotationAxisY_P" + playerNum));
        if (v != Vector2.zero)
        {
            float angle = Vector2.Angle(Vector2.up, v);

            if (v.x > 0)
            {
                angle *= -1;
            }

            gameObject.GetComponent<Player>().RotateStick(angle);
        }

        gameObject.GetComponent<Player>().Rotate((int) (rotate_speed * Input.GetAxisRaw("Rotation_P" + playerNum)));

        if (Input.GetButtonDown("Fire_P" + playerNum))
        {
            gameObject.GetComponent<Player>().Shoot();
        }
    }
}
