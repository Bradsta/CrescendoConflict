using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> players;
    public GameObject[] spawnPositions;

    void Start()
    {
        // initialize player colors
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // so that this can be called when you want to restart the game
    void StartGame()
    {
        // restart game music
        // delete all the waves
        /* for each player
         * re-enable all players' game object
         * health amount
          place them in their original spawn positions
         make them face the middle of the map
         */
        foreach (GameObject player in players)
        {

        }
    }
}
