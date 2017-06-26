using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour, IWeapon {

    public float damage;

    private Transform mainWeaponSlot;
    private Hit hit;
    private Animator myAnimator;
    private Camera myCamera;

    // Use this for initialization
    void Start () {
        hit = GetComponentInChildren<Hit>();
        hit.SetDamage(damage);

        mainWeaponSlot = transform.parent;
        myAnimator = GetComponent<Animator>();
        myCamera = FindObjectOfType<Camera>();
	}

    public void PerformAttack() {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            Vector2 attackDirection = GetAttackDirection;

            // Get attack rotation
            float attackRotationZ = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
            Quaternion attackRotation = Quaternion.Euler(new Vector3(0, 0, attackRotationZ - 90));


        }
    }

    Vector2 GetAttackDirection() {
        Vector2 mousePositionInWorld = myCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = new Vector2(mainWeaponSlot.position.x, mainWeaponSlot.position.y);
        Vector2 attackDirection = (mousePositionInWorld - playerPosition).normalized;
        return attackDirection;
    }

}
