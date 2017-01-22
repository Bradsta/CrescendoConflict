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

    private WaveAnimator waveAnimator; //to make the notes bounce

    PlayerHealth player; //ref to the health represented

    private int healthDisplayed; //tracks the amount of health being displayed

    public void Init(Sprite emptyHealth, GameObject healthPrefab, Sprite sprite, Color color, int health, PlayerHealth player) {
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
        healthDisplayed = health;

        this.player = player;
        this.emptyHealth = emptyHealth;

        waveAnimator = GetComponent<WaveAnimator>();
        waveAnimator.Init(this.health);
    }

    int lastHealth = -1;
    
    private void Update() {
        if (lastHealth == -1)
            lastHealth = player.health;

        if (lastHealth != player.health) //player took damage
        {
            int index = 0;
            switch (player.health)
            {
                case 75:
                    index = 3;
                    break;
                case 50:
                    index = 2;
                    break;
                case 25:
                    index = 1;
                    break;
                case 0:
                    index = 0;
                    break;
            }

            health[index].sprite = emptyHealth;
            lastHealth = player.health;
            waveAnimator.Run();
        }
    }

}
