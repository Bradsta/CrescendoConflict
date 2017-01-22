using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public GameObject Explosion;

    private GameManager gameManager;
    private SfxPlayer sfx;

    private List<GameObject> hits = new List<GameObject>();

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sfx = FindObjectOfType<SfxPlayer>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (hits.Contains(other.gameObject))
        {
            hits.Remove(other.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other != null
            && !hits.Contains(other.gameObject)
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

                    if (Explosion != null)
                    {
                        GameObject boom = Instantiate(Explosion);
                        boom.transform.position = playerHealth.gameObject.transform.position;

                        Destroy(boom, 1);
                    }
                }
            }

            hits.Add(other.gameObject);
        }
    }

}
