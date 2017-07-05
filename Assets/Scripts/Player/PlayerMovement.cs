using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;

    private Animator myAnimator;
    private Rigidbody2D myRigidbody;
    private bool canMove = true;

    private void OnEnable() {
        PlayerHealth.OnPlayerDeath += (() => canMove = false);
    }

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (canMove) {
            MoveAnimation();
        } else {
            StopMovementAnimation();
        }
    }

    public void Move(Vector2 moveDirection) {
        if (canMove) {
            myRigidbody.velocity = moveDirection * moveSpeed;
        } else {
            myRigidbody.velocity = Vector2.zero;
        }
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
            StopMovementAnimation();
        }
    }

    void StopMovementAnimation() {
        myAnimator.SetBool("MoveUp", false);
        myAnimator.SetBool("MoveDown", false);
        myAnimator.SetBool("MoveLeft", false);
        myAnimator.SetBool("MoveRight", false);
    }
    
}
