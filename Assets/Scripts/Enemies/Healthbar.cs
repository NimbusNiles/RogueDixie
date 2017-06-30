using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private Image healthBar;

    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    public void SetHealthbar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
    }
}
