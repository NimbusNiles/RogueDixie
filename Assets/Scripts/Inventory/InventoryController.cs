using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    public static InventoryController Instance { get; set; }
    public List<Item> playerItems = new List<Item>();

    public delegate void WeaponEquipAction(Item weapon);
    public static event WeaponEquipAction OnWeaponEquip;

    private void Start() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
    
    public void GiveItem(string itemName) {
        Item item = ItemDatabase.Instance.GetItem(itemName);
        playerItems.Add(item);

        switch (item.ItemType) {
            case Item.ItemTypes.Weapon_Melee:
                EquipWeapon(item);
                break;
        }
    }

    public void EquipWeapon(Item weaponToEquip) {
        GetComponent<PlayerWeaponController>().EquipWeapon(weaponToEquip);
        if(OnWeaponEquip != null) {
            OnWeaponEquip(weaponToEquip);
        }
    }

}
