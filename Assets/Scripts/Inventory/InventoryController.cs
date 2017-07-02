using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public static InventoryController Instance { get; set; }
    public List<Item> playerItems = new List<Item>();

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
    }

}
