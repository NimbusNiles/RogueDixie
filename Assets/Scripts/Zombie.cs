using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    
    private float recoilSpeed = 2f;
    private Player player;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            AttackPlayer();
        }
    }

    void AttackPlayer() {
        player.GetComponent<Health>().DealDamage(20f); //Deal damage to player
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        transform.Translate(-(directionToPlayer * recoilSpeed)); //Give velocity opposite to player's position, i.e. recoil
    }
}
