using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Player player;
    private Camera myCamera;

    private void Start() {
        player = FindObjectOfType<Player>();
        myCamera = FindObjectOfType<Camera>();
    }

    private void Update() {
        // Movement
        Vector2 moveDirection = GetMoveDirection();
        player.Move(moveDirection);

        // Attack
        if (Input.GetMouseButton(0)) {
            Vector2 mousePositionInWorld = myCamera.ScreenToWorldPoint(Input.mousePosition);
            player.MainAttack( mousePositionInWorld );
        }else if (Input.GetMouseButtonUp(0)) {
            player.StopAttack();
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
}
