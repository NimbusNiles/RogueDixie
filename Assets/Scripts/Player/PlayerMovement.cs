using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    [HideInInspector]
    public bool isDead = false;

    private Animator myAnimator;

    private Rigidbody2D myRigidbody;
    private Camera myCamera;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCamera = FindObjectOfType<Camera>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!isDead) {
            MoveAnimation();
        }
    }

    public void Move(Vector2 moveDirection) {
        if (!isDead) {
            myRigidbody.velocity = moveDirection * moveSpeed;
        } else {
            myRigidbody.velocity = Vector2.zero;
        }
    }

    
    public void MainAttack() {
        if (!isDead) {
            Vector2 attackDirection = GetAttackDirection();
            Quaternion attackRotation = GetAttackRotation(attackDirection);

            // finding weapon by IWeapon, only works with a single weapon equipped.
            GetComponentInChildren<IWeapon>().PerformAttack(attackDirection, attackRotation);
        }
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


    public void MoveAnimation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myAnimator.SetBool("MoveUp", true);
            myAnimator.SetBool("MoveDown", false);
            myAnimator.SetBool("MoveLeft", false);
            myAnimator.SetBool("MoveRight", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myAnimator.SetBool("MoveUp", false);
            myAnimator.SetBool("MoveDown", true);
            myAnimator.SetBool("MoveLeft", false);
            myAnimator.SetBool("MoveRight", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myAnimator.SetBool("MoveUp", false);
            myAnimator.SetBool("MoveDown", false);
            myAnimator.SetBool("MoveLeft", true);
            myAnimator.SetBool("MoveRight", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myAnimator.SetBool("MoveUp", false);
            myAnimator.SetBool("MoveDown", false);
            myAnimator.SetBool("MoveLeft", false);
            myAnimator.SetBool("MoveRight", true);
        }
        else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W))
        {
            myAnimator.SetBool("MoveUp", false);
            myAnimator.SetBool("MoveDown", false);
            myAnimator.SetBool("MoveLeft", false);
            myAnimator.SetBool("MoveRight", false);
        }
    }
        
}
