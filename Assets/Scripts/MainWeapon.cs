using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : MonoBehaviour {

    public float attackOffset = 0.5f;
    private Player player;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    public void Attack(Vector2 direction, Quaternion rotation) {
        transform.localPosition = direction * attackOffset;
        transform.rotation = rotation;

        player.AnimateMainAttack();
    }

}
