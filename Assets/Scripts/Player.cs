using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed;
    private Animator myAnimator;

    private Rigidbody2D myRigidbody;
    private Camera myCamera;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCamera = FindObjectOfType<Camera>();
    }

    public void Move(Vector2 moveDirection) {
        myRigidbody.velocity = moveDirection * moveSpeed;
        if (moveDirection.x == 1)
        {
            moveDirection = GetComponentInChildren<Animator>();
        }
        if (moveDirection.x == -1)
        {
            GetComponentInChildren<Animation>();
        }
        else if (moveDirection.y == 1)
        {
            GetComponentInChildren<Animation>();
        }
        else if (moveDirection.y == -1)
        {
            GetComponentInChildren<Animation>();
        }
    }

    public void MainAttack() {
        Vector2 attackDirection = GetAttackDirection();
        Quaternion attackRotation = GetAttackRotation(attackDirection);

        // finding weapon by IWeapon, only works with a single weapon equipped.
        GetComponentInChildren<IWeapon>().PerformAttack(attackDirection,attackRotation);
    }

    Vector2 GetAttackDirection() {
        Vector2 mousePositionInWorld = myCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 attackDirection = (mousePositionInWorld - playerPosition).normalized;
        return attackDirection;
    }

    Quaternion GetAttackRotation(Vector2 attackDirection) {
        float attackRotationZ = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Quaternion attackRotation = Quaternion.Euler(new Vector3(0, 0, attackRotationZ - 90));
        return attackRotation;
    }
}
