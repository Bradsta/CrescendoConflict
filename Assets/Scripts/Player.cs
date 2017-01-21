using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public GameObject Wave;
    public float Speed = 1;

    private Animator animator;
    private Rigidbody2D player;
    private Transform reticle;

    private byte state = 0; //Idle

    void Start() {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        reticle = transform.GetChild(0);
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
            player.MovePosition(new Vector2(player.position.x + Speed * directionx * Time.fixedDeltaTime, player.position.y + Speed * directiony * Time.fixedDeltaTime));

            if (state == 0)
            {
                state = 1; //Moving
                animator.Play("Walk");
            }
        }
    }

    public void Rotate(int rotate_speed)
    {
        reticle.RotateAround(player.transform.position, player.transform.forward, rotate_speed * 20 * Time.deltaTime);
    }

    public void Shoot()
    {
        //Instantiate(bullet, new Vector2(gun.position.x,gun.position.y), gun.transform.localRotation);

    }
}

