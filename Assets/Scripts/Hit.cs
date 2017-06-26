using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    private float hitDamage;

    public void SetDamage(float damage) {
        hitDamage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Health health = collision.GetComponent<Health>();
        if (health) {
            health.DealDamage(hitDamage);
        }
    }

}
