using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;
    public Image HUDHealthBar;
    public GameObject wastedScreen;

    private float currentHealth;
    private Player player;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
        currentHealth = maxHealth;
	}

    public void DealDamage(float damage) {
        currentHealth -= damage;
        HUDHealthBar.fillAmount = currentHealth/maxHealth;

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        player.isDead = true;
        wastedScreen.SetActive(true);
    }
}
