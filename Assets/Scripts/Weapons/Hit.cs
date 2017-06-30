using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    private IWeapon hitParent;

    private void Start() {
        hitParent = GetComponentInParent<IWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        hitParent.OnHit(collision);
    }

}
