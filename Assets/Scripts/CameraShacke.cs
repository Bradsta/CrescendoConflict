using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShacke : MonoBehaviour {

    private Transform cameraTrans;
    private GameManager gameManager;
    private GameObject player1;
    private GameObject player2;

    int Player1Health;
    int Player2Health;
    public int ShakeLength;
    private int OrigShakeLength;
    
    public Vector3 CameraLoc;


	// Use this for initialization
	void Start () {
        cameraTrans = gameObject.transform;
        gameManager = FindObjectOfType<GameManager>();

        foreach (GameObject go in gameManager.players)
        {
            Debug.Log(go);
        }

        player1 = gameManager.players[1];
        player2 = gameManager.players[2];

        Player2Health = player2.GetComponent<PlayerHealth>().health;
        Player1Health = player1.GetComponent<PlayerHealth>().health;
        CameraLoc = cameraTrans.position;
        OrigShakeLength = ShakeLength;
    }

    // Update is called once per frame
    void Update () {
        if ((player1 != null && player1.GetComponent<PlayerHealth>().health < Player1Health) || (player2 != null && player2.GetComponent<PlayerHealth>().health < Player2Health))
        {
           // camera.transform.position = new Vector3(Random.insideUnitCircle.x * ShakeLength, Random.insideUnitCircle.y * ShakeLength, camera.transform.position.z);

            if (ShakeLength > 0)
            {
                ShakeLength-=1;
                cameraTrans.position= new Vector3( Random.insideUnitCircle.x*.4f, cameraTrans.position.y, cameraTrans.position.z);
            }
            else
            {
                Player2Health = player2.GetComponent<PlayerHealth>().health;
                Player1Health = player1.GetComponent<PlayerHealth>().health;
                cameraTrans.position = CameraLoc;
                ShakeLength = OrigShakeLength;
            }

        }
	}
}
