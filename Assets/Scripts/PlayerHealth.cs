using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health = 200;

    public void TakeDamage(int amount)
    {
        health -= amount;
    }
}
