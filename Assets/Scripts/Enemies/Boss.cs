using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    private LevelManager levelManager;

    private void Start() {
        levelManager = GetComponent<LevelManager>();
    }

    private void Update() {
        if(transform.childCount <= 0) {
            levelManager.LoadNextLevel();
        }
    }
}
