using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (!playerHealth.IsDead)
            {
                playerHealth.TakeDamage(25);
            }
        }
    }

}
