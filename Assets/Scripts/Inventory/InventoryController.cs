using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public Item sword;

    private PlayerWeaponController playerWeaponController;

    private void Start() {
        playerWeaponController = FindObjectOfType<PlayerWeaponController>();
        sword = new Item("dagger_wood");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.V)) {
            playerWeaponController.EquipWeapon(sword);
        }
    }
}
