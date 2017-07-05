using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerResource : MonoBehaviour {

    public enum ResourceTypes { Rage, Mana, Stamina };
    public ResourceTypes MyResourceType { get; set; }
    
    public delegate void PlayerResourceDelegate(float currentResource, float maxResource);
    public static event PlayerResourceDelegate OnResourceChange;

    private float cooldownTimer;
    private float currentResource;

    public float Max { get; set; }
    public float Regen { get; set; }
    public float RegenCooldown { get; set; }

    public float Current {
        get { return currentResource; }
        set {
            currentResource = Mathf.Clamp(value, 0f, Max);
            if (OnResourceChange != null) {
                OnResourceChange(currentResource, Max);
            }
            cooldownTimer = 0f;
        }
    }
    
    private void Update() {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= RegenCooldown) {
            currentResource += (Regen * Time.deltaTime);
            OnResourceChange(currentResource, Max);
        }
    }
}
