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

    public void PerformAttack(Vector2 attackDirection, Quaternion attackRotation) {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {

            animationAnchor.localPosition = attackDirection * attackOffset;
            animationAnchor.localRotation = attackRotation;

            myAnimator.SetTrigger("Attack");
        }
    }

    

}
