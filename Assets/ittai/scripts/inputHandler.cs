using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour
{

    Rigidbody2D player;
    public Transform gun;
    public GameObject bullet;

    public Vector2 velocity;

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        //gun = GameObject.FindGameObjectWithTag("GUN").GetComponent<Rigidbody2D>();
    }


    public void move(float directionx, float directiony)
    {
        player.MovePosition(new Vector2(player.position.x + velocity.x * directionx * Time.fixedDeltaTime, player.position.y + velocity.y * directiony * Time.fixedDeltaTime));
        //gun.MovePosition(new Vector2(gun.position.x + velocity.x * directionx * Time.fixedDeltaTime, gun.position.y + velocity.y * directiony * Time.fixedDeltaTime));
    }

    public void Rotate(float rotate_speed)
    {
        gun.transform.RotateAround(player.transform.position, player.transform.forward, rotate_speed * 10);
        //gun.GetComponent<Rigidbody2D>().MoveRotation(gun.GetComponent<Rigidbody2D>().rotation+ rotate_speed);
        // gun.GetComponent<Rigidbody2D>().
    }


    public void RotateStick(float target)
    {

        Debug.Log(target);

        //Debug.Log(Input.GetAxis("rotationx"));
        float rad_target = target * Mathf.Deg2Rad;

        float OriginX = player.transform.position.x;//gun.transform.localPosition.x;
        float OriginY = player.transform.position.y; //gun.transform.localPosition.y; //
        float radius = 1f; //Mathf.Sqrt(Mathf.Pow(OriginX,2)+Mathf.Pow(OriginY,2));

        float TargetX = (OriginX + radius * (Mathf.Cos(rad_target)));//*Mathf.Rad2Deg) );
        float TargetY = (OriginY + radius * (Mathf.Sin(rad_target)));//*Mathf.Rad2Deg));

        //gun.MovePosition(new Vector2(TargetX,TargetY));
        gun.rotation = Quaternion.AngleAxis(target, Vector3.forward);


        //Debug.Log("Target is " + rad_target);
        //Debug.Log("originX squared = "+OriginX);
        //Debug.Log("originY squared = " + OriginY);
        //Debug.Log("xy squared combined = "+ Mathf.Pow(OriginX, 2) + Mathf.Pow(OriginY, 2));
        //Debug.Log("radius =" + radius);
        //Debug.Log("target x is = " + TargetX);
        //Debug.Log("target y is = " + TargetY);
        //Debug.Log("SHOFIHDSOI");


    }
    public void shoot()
    {
        Instantiate(bullet, new Vector2(gun.position.x, gun.position.y), gun.transform.localRotation);

    }
}
