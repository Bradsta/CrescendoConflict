using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {
    public Sprite[] characterImages;

    // var for storing the currently selected character
    private int selectedCharacter = 0;
	// Use this for initialization
	void Start () {
        GameVars.PlayerCount = 0;
	}

    void Update() {
        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") == 1)
        {
            ScrollUp();
        }
        else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") == -1)
        {
            ScrollDown();
        }

        if (Input.GetButtonDown("Submit"))
        {
            Progress();
        }
    }
 
    public void ScrollUp()
    {
        selectedCharacter--;
        //if it's about to hit less than 0, go back to the end
        if (selectedCharacter - 1 < 0)
            selectedCharacter = characterImages.Length - 1;
        updateDisp();
    }

    public void ScrollDown()
    {
        selectedCharacter++;
        //if it's about to be greater than the character list size, go back to the beginning
        if (selectedCharacter + 1 > characterImages.Length - 1)
            selectedCharacter = 0;
        updateDisp();
    }

    void updateDisp() {
        transform.GetChild(GameVars.PlayerCount).GetComponent<CharacterSelectFrame>().SetDisp(characterImages[selectedCharacter]);
    } 

    public void Progress() {
        //save the current character and move on
        GameVars.Avatars[GameVars.PlayerCount] = (GameVars.Avatar)selectedCharacter;
        if (GameVars.PlayerCount <= transform.childCount) { //use number of frames as indication of max number of characters 
            ++GameVars.PlayerCount;
            updateDisp();
        }else {
            //if out of frames, begin games
            BeginGame();
        }
    }

    public void BeginGame() {
        //begin the game
    }
}
