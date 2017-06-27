using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour, IWeapon {

    public float damage;
    public float attackOffset = 0.2f;
    
    private Hit hit;
    private Animator myAnimator;
    private Camera myCamera;
    private Transform animationAnchor;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();
        myCamera = FindObjectOfType<Camera>();
        animationAnchor = transform.GetChild(0);

        hit = GetComponentInChildren<Hit>();
        hit.SetDamage(damage);
	}

    public void PerformAttack() {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            Vector2 attackDirection = GetAttackDirection();
            Quaternion attackRotation = GetAttackRotation(attackDirection);

            animationAnchor.localPosition = attackDirection * attackOffset;
            animationAnchor.localRotation = attackRotation;

            myAnimator.SetTrigger("Attack");
        }
    }

    Vector2 GetAttackDirection() {
        Vector2 mousePositionInWorld = myCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = new Vector2(animationAnchor.position.x, animationAnchor.position.y);
        Vector2 attackDirection = (mousePositionInWorld - playerPosition).normalized;
        return attackDirection;
    }

    Quaternion GetAttackRotation(Vector2 attackDirection) {
        float attackRotationZ = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Quaternion attackRotation = Quaternion.Euler(new Vector3(0, 0, attackRotationZ - 90));
        return attackRotation;
    }

}
