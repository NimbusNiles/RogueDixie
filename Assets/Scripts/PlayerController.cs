using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Player player;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        // Attack
        if (Input.GetMouseButton(0)) {
            player.MainAttack();
        }else if (Input.GetMouseButtonUp(0)) {
           // player.StopAttack();
        }
    }

    private void FixedUpdate()
    {
        // Movement
        Vector2 moveDirection = GetMoveDirection();
        player.Move(moveDirection);
    }

    Vector2 GetMoveDirection() {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) {
            moveDirection.y = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            moveDirection.y = -1;
        } 

        if (Input.GetKey(KeyCode.D)) {
            moveDirection.x = 1;
        } else if (Input.GetKey(KeyCode.A)) {
            moveDirection.x = -1;
        } 

        return moveDirection;
    }
}
