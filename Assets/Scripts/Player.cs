using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveDirection) {
        myRigidbody.velocity = moveDirection * moveSpeed;
    }

    public void MainAttack() {
        // finding weapon by IWeapon, only works with a single weapon equipped.
        GetComponentInChildren<IWeapon>().PerformAttack();
    }

}
