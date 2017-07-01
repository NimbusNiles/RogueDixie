using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    private EndGate endGate;
    private TimeKeeper timeKeeper;

    private void Start() {
        endGate = FindObjectOfType<EndGate>();
        timeKeeper = FindObjectOfType<TimeKeeper>();
    }

    private void Update() {
        if(transform.childCount <= 0) {
            BossDefeated();
        }
    }

    void BossDefeated() {
        endGate.Open();
        timeKeeper.StopTicking();
    }
}
