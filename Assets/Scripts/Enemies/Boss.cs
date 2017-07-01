using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    private EndGate endGate;

    private void Start() {
        endGate = FindObjectOfType<EndGate>();
    }

    private void Update() {
        if(transform.childCount <= 0) {
            endGate.Open();
        }
    }
}
