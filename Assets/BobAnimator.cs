using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobAnimator : MonoBehaviour {

    public float Mag = 16; //maxnitude of sine wave
    public float Speed = 0.25f; //coefficient to adjust speed of bobing:w

	void Update () {
	    for(int i = 0; i < transform.childCount; ++i) {
            Transform t = transform.GetChild(i).transform;
            //extra costants in sign make odds and evens bob out of sync
            t.localPosition = new Vector3(t.localPosition.x, Mag * Mathf.Cos( Speed * Time.fixedTime * (((i % 2f) == 1) ? 1 : (23f / 57f)) % (2f*Mathf.PI)), 0);
        }	
	}
}
