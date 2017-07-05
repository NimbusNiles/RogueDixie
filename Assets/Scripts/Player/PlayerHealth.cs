using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;
    public static event Action OnPlayerDeath;

    public delegate void PlayerDamageDelegate(float damageAmount, float currentHealth, float maxHealth);
    public static event PlayerDamageDelegate OnPlayerDamage;

    private float currentHealth;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
	}

    public void DealDamage(float damage) {
        currentHealth -= damage;

        if (OnPlayerDamage != null) {
            OnPlayerDamage(damage, currentHealth, maxHealth);
        }

        if (currentHealth <= 0) {
            Die();
        }
    }
    
    void Die() {
        if (OnPlayerDeath != null) {
            OnPlayerDeath();
        }
    }
}
