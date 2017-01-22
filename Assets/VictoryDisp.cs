using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryDisp : MonoBehaviour {

    public Sprite[] sprites;

    public void Init(int winnerIndex) {
        //displays the given index as the winner
        transform.Find("Background").GetComponent<Image>().color = GameVars.Colors[winnerIndex];
        transform.Find("Image").GetComponent<Image>().sprite = sprites[winnerIndex];
    }

}
