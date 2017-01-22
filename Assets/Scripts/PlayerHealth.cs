using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    int health = 100;
    public int Health {
        get {
            return health;
        }
    }

    public bool IsDead {
        get {
            return health <= 0;
        }
    }

    public void TakeDamage (int amount)
    {
        health -= amount;
        if (IsDead)
        {
            // kill player??
        }
    }
}
