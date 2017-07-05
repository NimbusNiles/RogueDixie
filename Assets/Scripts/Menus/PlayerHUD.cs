using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public GameObject wastedScreen;
    public GameObject resourceBarObj;

    private Healthbar healthBar;
    private Healthbar resourceBar;

    private void OnEnable() {
        PlayerHealth.OnPlayerDeath += EnableWastedScreen;
        PlayerHealth.OnPlayerDamage += UpdateHealthBar;
        PlayerResource.OnResourceChange += UpdateResourceBar;
    }

    private void OnDisable() {
        PlayerHealth.OnPlayerDeath -= EnableWastedScreen;
        PlayerHealth.OnPlayerDamage -= UpdateHealthBar;
        PlayerResource.OnResourceChange -= UpdateResourceBar;
    }

    private void Start() {
        healthBar = GetComponentInChildren<Healthbar>();
        resourceBar = resourceBarObj.GetComponentInChildren<Healthbar>();
        SetResourceColor();
    }

    void EnableWastedScreen() {
        wastedScreen.SetActive(true);
    }

    void UpdateHealthBar(float damage, float currentHealth, float maxHealth) {
        healthBar.SetHealthbar(currentHealth, maxHealth);
    }

    void UpdateResourceBar(float currentResource, float maxResource) {
        resourceBar.SetHealthbar(currentResource, maxResource);
    }

    void SetResourceColor() {
        PlayerResource myResource = FindObjectOfType<PlayerResource>();
        switch (myResource.MyResourceType) {
            case PlayerResource.ResourceTypes.Mana:
                resourceBar.GetComponent<Image>().color = Color.blue;
                break;
            case PlayerResource.ResourceTypes.Rage:
                resourceBar.GetComponent<Image>().color = new Color(155f/255f, 0f, 189f/255f);
                break;
            case PlayerResource.ResourceTypes.Stamina:
                resourceBar.GetComponent<Image>().color = new Color(62f/255f, 210f/255f, 136f/255f);
                break;
            default:
                Debug.Log("ResourceType not recognized");
                break;
        }

    }

}
