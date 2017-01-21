using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusDisp : MonoBehaviour {

    //will also need to load full health if want to implement healing

    private static Vector2 healthBasePos = new Vector2(60, -20);
    private static Vector2 healthPosStep = new Vector2(24, 0);

    private Sprite emptyHealth;
    private Image image;
    private Image color;
    private List<Image> health; //notes that display health

    private int healthDisplayed; //tracks the amount of health being displayed

    public void Init(Sprite emptyHealth, GameObject healthPrefab, Sprite sprite, Color color, int health) {
        //pseudo constructor; to be called on object initialization
        //init objects
        image = transform.Find("Image").GetComponent<Image>();
        this.color = transform.Find("Color").GetComponent<Image>();
        this.health = new List<Image>();
        //image to disp empty health, obj to display (full) health, background image, number of health icons
        image.sprite = sprite;
        //set BG color
        this.color.color = color;
        //build health display
        Vector2 pos = healthBasePos;
        for(int i = 0; i < health; ++i) {
            GameObject go = Instantiate(healthPrefab);
            go.transform.SetParent(transform);
            go.transform.localPosition = pos + new Vector2(0, Random.Range(-8, 8));
            this.health.Add(go.GetComponent<Image>());
            pos += healthPosStep;
        } 
    }

    public void DispHealth (float newHealth) {
        //reduces heath displayed to given value
    }    

}
