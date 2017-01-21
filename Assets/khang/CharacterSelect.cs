using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {
    public List<Sprite> characterImages;
    //need to map each player to 1 index in this (list? map?)
    //stores the index for which character the player has selected
    // var for storing the currently selected character

	// Use this for initialization
	void Start () {
		//initialize player 1 or whichever players ready up
        //how do we detect when another player has entered the game?
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void ScrollUp()
    {
        //if it's about to hit less than 0, go back to the end
    }

    void ScrollDown()
    {
        //if it's about to be greater than the character list size, go back to the beginning
    }
}
