using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    Rigidbody2D barrel;
	// Use this for initialization
	void Start () {
        barrel = GameObject.FindGameObjectWithTag("GUN").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

		
	}
}
