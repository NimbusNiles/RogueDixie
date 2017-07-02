using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Image mainWeaponIcon;

    private void Start() {
        Item weapon = FindObjectOfType<PlayerWeaponController>().EquippedWeaponItem;
        if (weapon != null) {
            UpdateWeaponIcon(weapon);
        }
    }

    private void OnEnable() {
        InventoryController.OnWeaponEquip += UpdateWeaponIcon;
    }

    private void OnDisable() {
        InventoryController.OnWeaponEquip -= UpdateWeaponIcon;
    }

    void UpdateWeaponIcon(Item weapon) {
        mainWeaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Weapons/" + weapon.ObjectSlug);
        mainWeaponIcon.color = Color.white;
    }


}
