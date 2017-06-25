using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private Image healthbar;

    private void Start()
    {
        healthbar = GetComponent<Image>();
    }

    public void SetHealthbar(float currentHealth, float maxHealth)
    {
        healthbar.fillAmount = (currentHealth / maxHealth);
    }
}
