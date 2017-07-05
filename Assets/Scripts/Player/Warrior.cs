using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Warrior : MonoBehaviour, IClass {

    public float maxRage;
    public float rageCooldown;
    public float rageDegen;
    public string startingWeapon;
    
    private PlayerResource myResource;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        GetComponent<InventoryController>().GiveItem(startingWeapon);

        myResource = GetComponent<PlayerResource>();
        
        myResource.MyResourceType = PlayerResource.ResourceTypes.Rage;
        myResource.Max = maxRage;
        myResource.Regen = -rageDegen;
        myResource.RegenCooldown = rageCooldown;
        myResource.Current = 0;
    }

    public void AddRage(float amount) {
        myResource.Current += amount;
    }

    public bool SpendRage(float amount) {
        if (myResource.Current >= amount) {
            myResource.Current -= amount;
            return true;
        } else {
            return false;
        }
    }

}
