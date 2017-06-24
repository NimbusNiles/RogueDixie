using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100f;

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
