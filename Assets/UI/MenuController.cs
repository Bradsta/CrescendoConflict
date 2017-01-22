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

    private SfxPlayer sfx;

    void Start() {
        //plug in components
        //NOTE: because uses Find, do not rename game objects
        menu = GameObject.Find("MenuOptions");
        credits = GameObject.Find("Credits");
        settings = GameObject.Find("Settings");
        logo = GameObject.Find("Logo");
        controls = GameObject.Find("Controls");
        sfx = GameObject.FindObjectOfType<SfxPlayer>();
        //set to default state
        GotoState(State.MAIN, false);
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

    public void GotoState(State state, bool boop = true) {
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
        if(boop) sfx.PlaySoundEffect("menu select boop 1");
    }

    public void BeginGame() {
        SceneManager.LoadScene("Character Select");
    }

    public void ExitGame() {
        Application.Quit();
    }
    

}
