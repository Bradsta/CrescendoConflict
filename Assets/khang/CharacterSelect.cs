using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {
    public Sprite[] characterImages;
    //need to map each player to 1 index in this (list? map?)
    //stores the index for which character the player has selected
    // var for storing the currently selected character
    public int selectedCharacter = 0;
	// Use this for initialization

	void Start () {
        GameVars.PlayerCount = 0; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void ScrollUp()
    {
        selectedCharacter--;
        //if it's about to hit less than 0, go back to the end
        if (selectedCharacter - 1 < 0)
            selectedCharacter = characterImages.Length - 1;
    }

    void ScrollDown()
    {
        selectedCharacter++;
        //if it's about to be greater than the character list size, go back to the beginning
        if (selectedCharacter + 1 > characterImages.Length - 1)
            selectedCharacter = 0;
    }

    void Progress() {
        //save the current player and move on
        ++GameVars.PlayerCount;
    }
}
