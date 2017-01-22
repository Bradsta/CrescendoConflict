using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShacke : MonoBehaviour {

    public Camera camera;
    public GameObject player1;
    public GameObject player2;


    int Player1Health;
    int Player2Health;
    public int ShakeLength;
    private int OrigShakeLength;
    
    public Vector3 CameraLoc;


	// Use this for initialization
	void Start () {
        Player2Health = player2.GetComponent<PlayerHealth>().Health;
        Player1Health = player1.GetComponent<PlayerHealth>().Health;
        CameraLoc = camera.transform.position;
        OrigShakeLength = ShakeLength;

    }

    // Update is called once per frame
    void Update () {
        if (player1.GetComponent<PlayerHealth>().Health < Player1Health || player2.GetComponent<PlayerHealth>().Health < Player2Health)
        {
           // camera.transform.position = new Vector3(Random.insideUnitCircle.x * ShakeLength, Random.insideUnitCircle.y * ShakeLength, camera.transform.position.z);

            if (ShakeLength > 0)
            {
                ShakeLength-=1;
                Debug.Log (Random.insideUnitCircle.x+" "+Random.insideUnitCircle.y);
                camera.transform.position= new Vector3( Random.insideUnitCircle.x*.4f, camera.transform.position.y, camera.transform.position.z);
            }
            else
            {
                Player2Health = player2.GetComponent<PlayerHealth>().Health;
                Player1Health = player1.GetComponent<PlayerHealth>().Health;
                camera.transform.position = CameraLoc;
                ShakeLength = OrigShakeLength;
            }

        }
	}
}
