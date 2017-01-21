using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health = 100;
    public Text healthIndicator;

	// Use this for initialization
	void Start () {
        healthIndicator.text = health.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        healthIndicator.text = health.ToString();
    }

    void TakeDamage (int amount)
    {
        health -= amount;
    }
}
