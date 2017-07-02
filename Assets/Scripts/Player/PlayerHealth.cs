using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;

    private GameObject wastedScreen;
    private float currentHealth;
    private Player player;
    private Image HUDHealthBarImage;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
        currentHealth = maxHealth;
        UpdateHealthBar();
	}

    public void DealDamage(float damage) {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0) {
            Die();
        }
    }

    void UpdateHealthBar() {
        HUDHealthBarImage.fillAmount = currentHealth / maxHealth;
    }

    void Die() {
        player.IsDead = true;
        wastedScreen.SetActive(true);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += FindObjects;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= FindObjects;
    }

    void FindObjects(Scene scene, LoadSceneMode mode) {
        HUDHealthBarImage = GameObject.Find("HealthFull").GetComponent<Image>();
        wastedScreen = FindObjectOfType<PlayerHUD>().transform.Find("Wasted Screen").gameObject;
        UpdateHealthBar();
    }
}
