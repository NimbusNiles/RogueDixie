using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour, IWeapon {

    public float damage;
    public float attackOffset = 0.2f;
    public float rageAmount;
    
    private Animator myAnimator;
    private Transform animationAnchor;
    private Warrior warrior;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();
        animationAnchor = transform.GetChild(0);
        warrior = GetComponentInParent<Warrior>();
	}

    public void PerformAttack(Vector2 attackDirection, Quaternion attackRotation) {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {

            animationAnchor.localPosition = attackDirection * attackOffset;
            animationAnchor.localRotation = attackRotation;

            myAnimator.SetTrigger("Attack");
        }
    }

    public void OnHit(Collider2D collision) { 
        EnemyHealth health = collision.GetComponent<EnemyHealth>();
        if (health) {
            health.DealDamage(damage);
        }

        warrior.AddRage(rageAmount);
    }


}
