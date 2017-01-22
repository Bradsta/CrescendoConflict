using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {
    public Sprite[] characterImages;
    public Sprite xOutImage;

    // var for storing the currently selected character
    private int selectedCharacter = 0;

    private bool scrolledDown = false;
    private bool scrolledUp = false;
    private bool gameJamStrats = false;

	// Use this for initialization
	void Start () {
        GameVars.PlayerCount = 0;
	}

    void Update() {
        if (!gameJamStrats)
        {
            ScrollDown();
            gameJamStrats = true;
        }

        if (scrolledUp == false && Input.GetAxisRaw("Vertical_P" + (GameVars.PlayerCount + 1)) > 0.8f)
        {
            ScrollUp();
            scrolledUp = true;
        } else if (scrolledDown == false && Input.GetAxisRaw("Vertical_P" + (GameVars.PlayerCount + 1)) < -0.8f)
        {
            ScrollDown();
            scrolledDown = true;
        } else if (Input.GetButtonDown("Fire_P" + (GameVars.PlayerCount + 1)))
        {
            Progress();
        }

        if (Input.GetAxisRaw("Vertical_P" + (GameVars.PlayerCount + 1)) == 0)
        {
            scrolledDown = false;
            scrolledUp = false;
        }
    }
 
    public void ScrollUp()
    {
        selectedCharacter--;
        //if it's about to hit less than 0, go back to the end
        if (selectedCharacter < 0)
            selectedCharacter = characterImages.Length - 1;
        updateDisp();
    }

    public void ScrollDown()
    {
        selectedCharacter++;
        //if it's about to be greater than the character list size, go back to the beginning
        if (selectedCharacter > characterImages.Length - 1)
            selectedCharacter = 0;
        updateDisp();
    }

    void updateDisp() {
        transform.GetChild(GameVars.PlayerCount).GetComponent<CharacterSelectFrame>().SetDisp(legalPick(selectedCharacter)? characterImages[selectedCharacter] : xOutImage);
    } 

    public void Progress() {
        //save the current character and move on
        if (!legalPick(selectedCharacter)) return; //DO NOT RUN THE FUNCTION IF NOT LEGAL PICK
        GameVars.Avatars[GameVars.PlayerCount] = (GameVars.Avatar)selectedCharacter;
        if (GameVars.PlayerCount < transform.childCount-1) { //use number of frames as indication of max number of characters 
            ++GameVars.PlayerCount;
            ScrollDown();
            updateDisp();
        } else {
            //if out of frames, begin games
            BeginGame();
        }
    }

    private bool legalPick(int characterIndex) {
        //returns true if the character at the given index hasn't been picked yet
        for(int i = 0; i < GameVars.PlayerCount; ++i) {
            if (GameVars.Avatars[i] == (GameVars.Avatar)characterIndex) {
                return false;
            }
        }
        return true;
    }

    public void BeginGame() {
        Debug.Log("FAK");
        SceneManager.LoadScene("Game");
    }
}
