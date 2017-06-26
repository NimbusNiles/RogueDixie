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

    public void MainAttack(Vector2 mousePositionInWorld) {
        GetComponentInChildren<IWeapon>().PerformAttack();
    }

}
