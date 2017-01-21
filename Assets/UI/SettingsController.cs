using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    private Toggle twoPlayer;

    private void Start() {
        //link objects
        twoPlayer = transform.Find("PlayerCount/TwoPlayer").GetComponent<Toggle>(); //two player toggle must be named correctly
    }

    public void UpdateSettings() {
        //load settings into GameVars
        GameVars.PlayerCount = twoPlayer.isOn ? 2 : 4; //currently assumes player count = 2 XOR player count = 4
    }

}
