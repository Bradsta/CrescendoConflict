using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour {

    Rigidbody2D player;
    Rigidbody2D gun;
    public GameObject bullet;

    public Vector2 velocity;

    // Use this for initialization
    void Start() {
        player = gameObject.GetComponent<Rigidbody2D>();
        gun = GameObject.FindGameObjectWithTag("GUN").GetComponent<Rigidbody2D>();
    }


    public void move(float directionx,float directiony)
    {
        player.MovePosition(new Vector2(player.position.x + velocity.x * directionx * Time.fixedDeltaTime, player.position.y + velocity.y *directiony * Time.fixedDeltaTime));
        gun.MovePosition(new Vector2(gun.position.x + velocity.x * directionx * Time.fixedDeltaTime, gun.position.y + velocity.y * directiony * Time.fixedDeltaTime));
    }

    public void Rotate(float rotate_speed)
    {
        gun.transform.RotateAround(player.transform.position, player.transform.forward, rotate_speed*20 * Time.deltaTime);
        //gun.GetComponent<Rigidbody2D>().MoveRotation(gun.GetComponent<Rigidbody2D>().rotation+ rotate_speed);
       // gun.GetComponent<Rigidbody2D>().
    }


    public void RotateStick(float target)
    {
      
        float OriginX =gun.transform.position.x;
        float OriginY =gun.transform.position.y; //
        float radius = Mathf.Sqrt(Mathf.Pow(OriginX,2)+Mathf.Pow(OriginY,2));

        float TargetX =(OriginX + radius * Mathf.Cos(target)*Mathf.Deg2Rad);
        float TargetY =(OriginY + radius * Mathf.Sin(target) * Mathf.Deg2Rad);
        Debug.Log("Target is " + target);
        //Debug.Log("originX squared = "+Mathf.Pow(OriginX, 2));
        //Debug.Log("originY squared = " + Mathf.Pow(OriginY, 2));
        //Debug.Log("xy squared combined = "+ Mathf.Pow(OriginX, 2) + Mathf.Pow(OriginY, 2));
        //Debug.Log("radius =" + radius);
        Debug.Log("target x is = " + TargetX);
        Debug.Log("target y is = " + TargetY);
        gun.MovePosition(new Vector2(TargetX, TargetY));
        // Vector3 origin = gun.transform.position ;
          //gun.transform.position = Vector3.Slerp(new Vector3(OriginX,OriginY,0), new Vector3(TargetX,TargetY,0),1f);
        //Quaternion NewRotation = new Quaternion(0, 0, target,0); 
        //gun.transform.rotation = Quaternion.Slerp(transform.rotation, NewRotation, Time.deltaTime * 3f);
        //gun.GetComponent<Rigidbody2D>().MoveRotation(gun.GetComponent<Rigidbody2D>().rotation+ rotate_speed);
        // gun.GetComponent<Rigidbody2D>().
    }
    public void shoot()
    {
        Instantiate(bullet, new Vector2(gun.position.x,gun.position.y), gun.transform.localRotation);

    }
}

