using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public enum State { MAIN, CREDITS, SETTINGS, CONTROLS }

    private GameObject menu;
    private GameObject credits;
    private GameObject settings;
    private GameObject logo;
    private GameObject controls;

    void Start() {
        //plug in components
        //NOTE: because uses Find, do not rename game objects
        menu = GameObject.Find("MenuOptions");
        credits = GameObject.Find("Credits");
        settings = GameObject.Find("Settings");
        logo = GameObject.Find("Logo");
        controls = GameObject.Find("Controls");
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
            int mPos = (state == State.MAIN) ? 0 : 256; 
            RectTransform rt = menu.GetComponent<RectTransform>();
            rt.localScale = new Vector3(mScale, mScale, 0);
            rt.localPosition = new Vector3(mPos, rt.localPosition.y, 0);
        }
        credits.SetActive(state == State.CREDITS);
        settings.SetActive(state == State.SETTINGS);
        logo.SetActive(state == State.MAIN);
        controls.SetActive(state == State.CONTROLS);
    }

    public void BeginGame() {
        SceneManager.LoadScene("Character Select");
    }

    public void ExitGame() {
        Application.Quit();
    }
    

}
