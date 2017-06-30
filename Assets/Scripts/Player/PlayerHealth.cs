using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;
    public GameObject HUDHealthBar;
    public GameObject wastedScreen;

    private float currentHealth;
    private PlayerMovement player;
    public Image HUDHealthBarImage;

    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerMovement>();
        //HUDHealthBarImage = HUDHealthBar.transform.GetChild(1).gameObject.GetComponent<Image>();
        currentHealth = maxHealth;

        Debug.Log(HUDHealthBarImage);
	}

    public void DealDamage(float damage) {
        currentHealth -= damage;
        HUDHealthBarImage.fillAmount = currentHealth/maxHealth;
        Debug.Log(currentHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        player.isDead = true;
        wastedScreen.SetActive(true);
    }
}
