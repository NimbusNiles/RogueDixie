using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    public int value = 3;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            PlayerLoot.coinAmount += value;
            Debug.Log(PlayerLoot.coinAmount);
            Destroy(this.gameObject);
        }
    }
}
