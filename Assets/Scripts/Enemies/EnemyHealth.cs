using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float health = 100f;
    private float maxHealth;
    private Healthbar healthBar;

    void Start()
    {
        maxHealth = health;     //If we plan on increasing/decreasing maxHealth after enemy instantiation, we might need a more elegant solution to give this its value
        healthBar = GetComponentInChildren<Healthbar>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (healthBar)          //Since player doesn't have a health bar (yet) and also uses this method, checks to see if healthBar == null
        {
            healthBar.SetHealthbar(health, maxHealth);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die() {
        GetComponentInParent<DropCoins>().Drop(this.gameObject);
        Destroy(gameObject);
    }
}
