using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private GameManager gameManager;
    private SfxPlayer sfx;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sfx = FindObjectOfType<SfxPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null
            && other.gameObject.activeSelf
            && other.GetComponent<Player>() != null)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            Player p = other.GetComponent<Player>();
            CharacterInfo ci = p != null ? p.characterInfo : null;

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(25);

                if (ci != null && ci.ClipOnHit != null && sfx != null)
                    sfx.PlaySoundEffect(ci.ClipOnHit);

                if (playerHealth.health <= 0
                    && gameManager.players.Contains(playerHealth.gameObject))
                {
                    gameManager.players.Remove(playerHealth.gameObject);
                    playerHealth.gameObject.SetActive(false);
                }
            }
        }
    }

}
