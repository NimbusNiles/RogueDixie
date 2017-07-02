using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    [HideInInspector]

    private Animator myAnimator;
    private Rigidbody2D myRigidbody;
    private Player player;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!player.IsDead) {
            MoveAnimation();
        }
    }

    public void Move(Vector2 moveDirection) {
        if (!player.IsDead) {
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
            myAnimator.SetBool("MoveUp", false);
            myAnimator.SetBool("MoveDown", false);
            myAnimator.SetBool("MoveLeft", false);
            myAnimator.SetBool("MoveRight", false);
        }
    }

    
}
