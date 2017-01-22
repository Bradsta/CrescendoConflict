using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputPasser : MonoBehaviour {

    public int rotate_speed;
    public string playerHorz; //for when we add second player, so like Horizontal2, to get the axis for the second player
    public string playerVert;
    public string KeyCounterClockwise;
    public string KeyClockwise;
    public string ContStickVertR;
    public string ContStickHorzR;



    Rigidbody2D gun;
    // Use this for initialization
    void Start () {
    Rigidbody2D  gun = GameObject.FindGameObjectWithTag("GUN").GetComponent<Rigidbody2D>();
	}

    void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate() {

        gameObject.GetComponent<inputHandler>().move(Input.GetAxisRaw(playerHorz), Input.GetAxisRaw(playerVert));


        //float rightstickvert = Input.GetAxis("rotationy");

        float angle = Mathf.Atan2(-Input.GetAxisRaw("rotationy"), Input.GetAxisRaw("rotationx")) * Mathf.Rad2Deg;

        gameObject.GetComponent<inputHandler>().RotateStick(angle);

/*
        //Debug.Log(Input.GetAxis("rotationx"));
        float rad_target = angle * Mathf.Deg2Rad;
        
        float OriginX = gameObject.transform.position.x;//gun.transform.localPosition.x;
        float OriginY = gameObject.transform.position.y; //gun.transform.localPosition.y; //
        float radius = 1f; //Mathf.Sqrt(Mathf.Pow(OriginX,2)+Mathf.Pow(OriginY,2));

        float TargetX = (OriginX + radius * (Mathf.Cos(rad_target)));//*Mathf.Rad2Deg) );
        float TargetY = (OriginY + radius * (Mathf.Sin(rad_target)));//*Mathf.Rad2Deg));

        gun.MovePosition(new Vector2(TargetX, TargetY));
        gun.rotation = angle;*/



        if (Input.GetKey("o"))
            gameObject.GetComponent<inputHandler>().Rotate(rotate_speed);
        if (Input.GetKey("p"))
            gameObject.GetComponent<inputHandler>().Rotate(rotate_speed * -1);
        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.GetComponent<inputHandler>().shoot();
        }
        //if (Input.GetAxis("rotationx") != 0 || Input.GetAxis("rotationy") != 0)
        //{
        
            //float angle=0.0f;
            // Vector2 directions = new Vector2(Input.GetAxisRaw("rotationx"), -Input.GetAxisRaw("rotationy"));
           /* if (-Input.GetAxis("rotationy") < 0)
            {
                angle += 360;
            }
            if (angle == -180)
                angle = 180;

                //print(angle);*/
        //}

    }
}
