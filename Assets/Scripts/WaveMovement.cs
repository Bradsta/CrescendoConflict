using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    [Tooltip("In units per second, default is 6.40 #MagicNumber.")]
    public float Speed = 6.40f;
    [Tooltip("In units per second, default is 0.0125 #MagicNumber.")]
    public float ScaleSpeed = 0.0125f;

    private Vector2 direction;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        direction = transform.up;
    }

    void FixedUpdate()
    {
        transform.localScale += new Vector3(ScaleSpeed, ScaleSpeed, 1);

        rb2d.MovePosition(rb2d.position + (direction * Speed * Time.fixedDeltaTime));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 reflection = Vector2.Reflect(direction, coll.contacts[0].normal);

        transform.up = reflection;
        direction = reflection;
    }
}
