using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100f;
    private float maxHealth;
    private Healthbar healthbar;

    void Start()
    {
        maxHealth = health;     //If we plan on increasing/decreasing maxHealth after enemy instantiation, we might need a more elegant solution to give this its value.
        healthbar = GetComponentInChildren<Healthbar>();
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (healthbar)          //Since player doesn't have a healthbar (yet) and also uses this method, checks to see if healthbar == null.
        {
            healthbar.SetHealthbar(health, maxHealth);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
