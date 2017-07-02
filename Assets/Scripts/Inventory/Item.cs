using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public string ObjectSlug { get; set; }

    public Item(string _ObjectSlug) {
        this.ObjectSlug = _ObjectSlug;
    }
}
