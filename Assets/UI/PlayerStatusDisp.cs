using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusDisp : MonoBehaviour {

    private static Image emptyHealth;
    //will also need to load full health if want to implement healing

    private static GameObject healthPrefab;
    private static Vector2 healthBasePos = new Vector2(67, -16);
    private static Vector2 healthPosStep = new Vector2(32, 0);

    Image image;
    List<Image> health; //notes that display health

    private void Start() {
        //link objects
        image = transform.Find("Image").GetComponent<Image>();
    }

    public void Init(Sprite sprite, int health) {
        //pseudo constructor; to be called on object initialization
        image.sprite = sprite;
        //build health displa
        Vector2 pos = healthBasePos;
        for(int i = 0; i < health; ++i) {
            GameObject go = Instantiate(healthPrefab);
            go.transform.parent = transform;
            go.transform.position = pos + new Vector2(0, Random.Range(-8, 8));
            this.health.Add(go.GetComponent<Image>());
            pos += healthPosStep;
        } 
    }

}
