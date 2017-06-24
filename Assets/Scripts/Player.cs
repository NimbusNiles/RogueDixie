using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private MainWeapon mainWeapon;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mainWeapon = GetComponentInChildren<MainWeapon>();
    }

    public void Move(Vector2 moveDirection) {
        myRigidbody.velocity = moveDirection * moveSpeed;
    }

    public void MainAttack(Vector2 mousePositionInWorld) {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            // Get attack position
            Vector2 attackDirection = (mousePositionInWorld - new Vector2(transform.position.x, transform.position.y)).normalized;

            // Get attack rotation
            float attackRotationZ = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
            Quaternion attackRotation = Quaternion.Euler(new Vector3(0, 0, attackRotationZ - 90));

            mainWeapon.Attack(attackDirection, attackRotation);
        }
    }

    public void AnimateMainAttack() {
        myAnimator.SetBool("isAttacking", true);
    }

    public void StopAttack() {
        myAnimator.SetBool("isAttacking", false);
    }
}
