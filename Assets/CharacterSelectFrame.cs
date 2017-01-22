using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectFrame : MonoBehaviour {

    Image character;

	// Use this for initialization
	void Start () {
        character = transform.Find("Character").GetComponent<Image>();
        character.gameObject.SetActive(false);
	}

    public void SetDisp (Sprite sprite) {
        character.gameObject.SetActive(true);
        character.sprite = sprite;
    }
	
}
