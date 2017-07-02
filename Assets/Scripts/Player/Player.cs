using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool IsDead { get; set; }

    private void Start() {
        IsDead = false;
    }
}
