using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour {

    private static Vector2 dispBasePos = new Vector2(67, -71);
    private static Vector2 dispPosStep = new Vector2(0, -160);

    public GameObject psdPrefab; //Player Status Disp; public so can plug in from unity
    public GameObject healthPrefab; //public so can plug in from unity
    public Sprite emptyHealthImage; //publis so...
    public Sprite[] portraits; //you know the drill; also should be in order DOM TING PLINK MANA

	// Use this for initialization
	void Start () {
        //load prefabs
        Vector2 pos = dispBasePos;
        GameManager gm = FindObjectOfType<GameManager>();
        for (int i = 0; i < gm.players.Count-1; ++i) {
            //see Player Status Disp for comments, because its the same $T^)# algorithm
            Debug.Log(i.ToString() + " : " + gm.players.Count.ToString());
            GameObject go = Instantiate(psdPrefab);
            go.transform.SetParent(transform);
            go.transform.localPosition = pos;
            Debug.Log(gm.players[i+1]);
            Debug.Log(go);
            go.transform.GetComponent<PlayerStatusDisp>().Init(emptyHealthImage,
                                                               healthPrefab,
                                                               portraits[(int)GameVars.Avatars[i]],
                                                               GameVars.Colors[i], 
                                                               4, //NUMBER OF NOTES HARDCODED HERE
                                                               gm.players[i+1].GetComponent<PlayerHealth>()); 
            pos += dispPosStep;
        }
		
	}
	
}
