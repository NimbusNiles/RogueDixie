using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerMovement player;

    //Ramon: Sprites for animation
    public Sprite frontside;
    public Sprite backside;
    public Sprite leftside;
    public Sprite rightside;


    private void Start() {
        player = FindObjectOfType<PlayerMovement>();
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

            //RAMON: player animation
            GameObject.Find("Body Sprite").GetComponent<SpriteRenderer>().sprite = backside;

        } else if (Input.GetKey(KeyCode.S)) {
            moveDirection.y = -1;

            //RAMON: player animation
            GameObject.Find("Body Sprite").GetComponent<SpriteRenderer>().sprite = frontside;
        } 

        if (Input.GetKey(KeyCode.D)) {
            moveDirection.x = 1;

            //RAMON: player animation
            GameObject.Find("Body Sprite").GetComponent<SpriteRenderer>().sprite = rightside;

        } else if (Input.GetKey(KeyCode.A)) {
            moveDirection.x = -1;

            //RAMON: player animation
            GameObject.Find("Body Sprite").GetComponent<SpriteRenderer>().sprite = leftside;
        } 

        return moveDirection;
    }
}
