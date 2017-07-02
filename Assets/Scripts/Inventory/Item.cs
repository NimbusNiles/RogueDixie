using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public enum ItemTypes {Weapon_Melee, Weapon_Ranged, Weapon_Magic, Consumable }
    public string ObjectSlug { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    public int LevelReq { get; set; }
    public float APS { get; set; }

    [Newtonsoft.Json.JsonConstructor]
    public Item(string _ObjectSlug, string _ItemName, string _Description, ItemTypes _ItemType, int _LevelReq, float _APS) {
        this.ObjectSlug = _ObjectSlug;
        this.ItemName = _ItemName;
        this.Description = _Description;
        this.ItemType = _ItemType;
        this.LevelReq = _LevelReq;
        this.APS = _APS;
    }
}
