using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float Rotation = 0;
    public float Speed = 0.1f;

    private Vector2 direction;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        direction = (Vector2)transform.up * -1;
    }

    void FixedUpdate()
    {
        transform.localScale += new Vector3(0.001f, 0.001f, 1);

        rb2d.MovePosition(rb2d.position + (direction * Speed * Time.fixedDeltaTime));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 reflection = Vector2.Reflect(direction, coll.contacts[0].normal);

        transform.up = -reflection; //Rotate wave
        direction = reflection;
    }
}
