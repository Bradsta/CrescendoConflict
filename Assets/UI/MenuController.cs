using System.Collections;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public enum State { MAIN, CREDITS, SETTINGS }

    private GameObject menu;
    private GameObject credits;
    private GameObject settings;

    void Start() {
        //plug in components
        //NOTE: because uses Find, do not rename game objects
        menu = GameObject.Find("MenuOptions");
        credits = GameObject.Find("Credits");
        settings = GameObject.Find("Settings");
        //set to default state
        GotoState(State.MAIN);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GotoState(State.MAIN);
        }
    }

    public void GotoState(int i) {
        //wrapper that allows GotoState to be called by Unity
        GotoState((State)i);
    }

    public void GotoState(State state) {
        //change settings to display the given state
        { //so that don't keep mScale around longer than need to
            float mScale = (state == State.MAIN) ? 1 : 0.75f;
            menu.GetComponent<RectTransform>().localScale = new Vector3(mScale, mScale, 0);
        }
        credits.SetActive(state == State.CREDITS);
        settings.SetActive(state == State.SETTINGS);
    }

    public void BeginGame() {
        //code to begin the game
        //load settings into GameVars
        //TODO: make sure doesn't have problems being inactive
        settings.GetComponent<SettingsController>().UpdateSettings(); //requires settings controller on settings parent object
        //TODO: go to the scene, once it exists
    }
    

}
