using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public GameObject attackOrigin;
    public float meleeAttackOffset;

    private Camera myCamera;
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;

    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCamera = FindObjectOfType<Camera>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update() {
        // Movement
        Vector2 moveDirection = GetMoveDirection();
        myRigidBody.velocity = moveDirection * moveSpeed;

        // Attack
        if (Input.GetMouseButton(0) && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            Vector2 mousePosition = myCamera.ScreenToWorldPoint(Input.mousePosition);

            // Set position
            Vector2 attackDirection = (mousePosition - new Vector2(transform.position.x,transform.position.y));
            attackOrigin.transform.localPosition = attackDirection.normalized * meleeAttackOffset;

            // Set rotation
            float attackRotationZ = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
            attackOrigin.transform.rotation = Quaternion.Euler(new Vector3(0, 0, attackRotationZ - 90));

            myAnimator.SetBool("isAttacking", true);
            
        }

        if (Input.GetMouseButtonUp(0)) {
            myAnimator.SetBool("isAttacking", false);
        }
    }

    Vector2 GetMoveDirection() {

        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) {
            moveDirection.y = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            moveDirection.y = -1;
        } else {
            moveDirection.y = 0;
        }

        if (Input.GetKey(KeyCode.D)) {
            moveDirection.x = 1;
        } else if (Input.GetKey(KeyCode.A)) {
            moveDirection.x = -1;
        } else {
            moveDirection.x = 0;
        }

        return moveDirection;

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print(collision + "rekt");
    }
}
