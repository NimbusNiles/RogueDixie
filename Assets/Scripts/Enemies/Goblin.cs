using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {

    public float attackRange = 1f;

    private PlayerMovement player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>();
	}

    private void FixedUpdate() {
        // Find the distance to the player
        Vector2 posDelta = player.transform.position - transform.position;
        float distanceToPlayer = posDelta.magnitude;


        if (distanceToPlayer <= attackRange) {
            Vector2 attackDirection = posDelta.normalized;
            Quaternion attackRotation = GetAttackRotation(attackDirection);

            // finding weapon by IWeapon, only works with a single weapon equipped.
            GetComponentInChildren<IWeapon>().PerformAttack(attackDirection, attackRotation);
        }
    }
    
    Quaternion GetAttackRotation(Vector2 attackDirection) {
        float attackRotationZ = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Quaternion attackRotation = Quaternion.Euler(new Vector3(0, 0, attackRotationZ - 90));
        return attackRotation;
    }
}
