using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    public int value = 3;
    public bool magnetized;
    public float speed = 3f;

    private PlayerMovement player;

    private void OnEnable() {
        magnetized = false;
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerLoot.coinAmount += value;
            Debug.Log(PlayerLoot.coinAmount);
            gameObject.SetActive(false);
        } else if (collision.gameObject.name == "Coin Magnet") {
            magnetized = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name == "Coin Magnet") {
            magnetized = false;
        }
    }

    private void FixedUpdate() {
        if (magnetized) {
            Vector2 posDelta = player.transform.position - transform.position;
            float distanceToPlayer = posDelta.magnitude;
            Vector2 directionToPlayer = posDelta.normalized;
            Vector2 velocity = directionToPlayer * Mathf.Clamp(speed / distanceToPlayer,0,15);
            transform.Translate(velocity * Time.fixedDeltaTime);
        }
    }
}