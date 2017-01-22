using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveAnimator : MonoBehaviour {

    //MAKE GAME OBJECTS DO "THE WAVE"

    private List<GameObject> objs;    
    private float state; //tracks state in wave; -2 for not running, -1 for starting
    private int mag;
    
    public void Init(List<Image> objs) { //specifically for use with Player status disp
        this.objs = new List<GameObject>();
        foreach(var i in objs) {
            this.objs.Add(i.gameObject);
        }
    }

    public void Init(List<GameObject> objs, int mag = 8) {
        this.objs = objs;
        this.mag = mag;
        state = -2;
    }

    public void Run() {
        //begin waving
        if (state < -2) state = -0.9f;
    }

    void Update() {
        if(state >= -1) { //if waving
            Debug.Log("WAVING "+state.ToString());
            if (state > 0 && state == (int)state ) objs[(int)state].transform.position -= new Vector3(0, mag, 0); //if not first position, move down prev position
            state += 0.1f; //move to next position
            if (state < objs.Count && state == (int)state ) objs[(int)state].transform.position += new Vector3(0, mag, 0); //it are more positions, move up new position 
            else if (state >= objs.Count) state = -2; //if are not more positions, set to not waving
        }
    }

}