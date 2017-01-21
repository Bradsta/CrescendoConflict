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
        int pc = GameVars.PlayerCount;
        for(int i = 0; i < pc; ++i) {
            //see Player Status Disp for comments, because its the same $T^)# algorithm
            Debug.Log(i);
            GameObject go = Instantiate(psdPrefab);
            go.transform.SetParent(transform);
            go.transform.localPosition = pos;
            go.transform.GetComponent<PlayerStatusDisp>().Init(emptyHealthImage,
                                                               healthPrefab,
                                                               portraits[(int)GameVars.Avitars[i]],
                                                               GameVars.Colors[i], 
                                                               4); //NUMBER OF NOTES HARDCODED HERE
            pos += dispPosStep;
        }
		
	}
	
}
