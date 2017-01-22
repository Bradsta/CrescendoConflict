using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject PlayerPrefab;

    public GameObject[] characterPrefabs;

    public List<GameObject> players;
    public GameObject[] spawnPositions;

    void Awake()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // so that this can be called when you want to restart the game
    void StartGame()
    {
        for (int i=0; i<=GameVars.PlayerCount; i++)
        {
            GameObject spawnpoint = GameObject.Find("Spawnpoint " + (i + 1));

            GameObject player = Instantiate(PlayerPrefab);
            player.transform.position = spawnpoint.transform.position;

            player.GetComponent<Player>().PlayerNumber = (PlayerNumber) i;
            player.GetComponent<Player>().playerNum = i + 1;

            players.Add(player);

            GameObject character = Instantiate(characterPrefabs[(int)GameVars.Avatars[i]]);
            character.transform.parent = player.transform;
            character.transform.localPosition = Vector2.zero;
        }
        // restart game music
        // delete all the waves
        /* for each player
         * re-enable all players' game object
         * health amount
          place them in their original spawn positions
         make them face the middle of the map
         */
    }
}
