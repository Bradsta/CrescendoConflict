using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public PlayerNumber PlayerNumber = PlayerNumber.PLAYER_1;
    [HideInInspector]
    public int playerNum = 1;

    private float Speed = 2.56f;

    private Animator animator;
    private Rigidbody2D player;
    private Transform reticle;
    private Transform src;
    private float lastShot = -1;

    private byte state = 0; //Idle

    private SfxPlayer sfxPlayer;
    private CharacterInfo characterInfo;

    void Start() {
        sfxPlayer = FindObjectOfType<SfxPlayer>();
        player = GetComponent<Rigidbody2D>();

        src = transform.Find("Source");
        reticle = src.Find("Reticle");

        characterInfo = gameObject.GetComponentInChildren<CharacterInfo>();
        animator = characterInfo.gameObject.GetComponent<Animator>();

        switch (PlayerNumber)
        {
            case PlayerNumber.PLAYER_1:
                playerNum = 1;
                break;
            case PlayerNumber.PLAYER_2:
                playerNum = 2;
                break;
            case PlayerNumber.PLAYER_3:
                playerNum = 3;
                break;
            case PlayerNumber.PLAYER_4:
                playerNum = 4;
                break;
            case PlayerNumber.PLAYER_N: //Oh god ryan why
                break;
        }
    }

    public void move(float directionx,float directiony)
    {
        if (directionx == 0 && directiony == 0) //Not moving
        {
            if (state == 1) //Was moving previously
            {
                state = 0;
                animator.Play("Idle");
            }
        }
        else
        {
            player.MovePosition(new Vector2(transform.position.x + Speed * directionx * Time.fixedDeltaTime, transform.position.y + Speed * directiony * Time.fixedDeltaTime));

            if (state == 0)
            {
                state = 1; //Moving
                animator.Play("Walk");
            }
        }
    }

    public void Rotate(int rotate_speed)
    {
        src.Rotate(0, 0, rotate_speed * 20 * Time.deltaTime);
    }

    public void RotateStick(float target)
    {
        src.rotation = Quaternion.AngleAxis(target, Vector3.forward);
    }

    public void Shoot()
    {
        if (lastShot == -1 || (Time.time - lastShot) > 1)
        {
            sfxPlayer.PlaySoundEffect(characterInfo.ShootClipName);

            Instantiate(characterInfo.Wave, reticle.position + (reticle.up / 10f), Quaternion.Euler(0, 0, reticle.rotation.eulerAngles.z));
            reticle.GetComponent<Animator>().Play("Charging", 0, 0);
            lastShot = Time.time;
        }
    }
}

