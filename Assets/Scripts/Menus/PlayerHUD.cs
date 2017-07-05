using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public GameObject wastedScreen;

    private Healthbar healthBar;

    private void OnEnable() {
        PlayerHealth.OnPlayerDeath += EnableWastedScreen;
        PlayerHealth.OnPlayerDamage += UpdateHealthBar;
    }

    private void OnDisable() {
        PlayerHealth.OnPlayerDeath -= EnableWastedScreen;
        PlayerHealth.OnPlayerDamage -= UpdateHealthBar;
    }

    private void Start() {
        healthBar = GetComponentInChildren<Healthbar>();
    }

    void EnableWastedScreen() {
        wastedScreen.SetActive(true);
    }

    void UpdateHealthBar(float damage, float currentHealth, float maxHealth) {
        healthBar.SetHealthbar(currentHealth, maxHealth);
    }

}
