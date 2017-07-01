using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGate : MonoBehaviour {

    public Sprite openedSprite;
    public bool startsOpen;

    private LevelManager levelManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        if (startsOpen) {
            Open();
        }
    }

    public void Open() {
        GetComponent<SpriteRenderer>().sprite = openedSprite;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovement>()) {
            levelManager.LoadNextLevel();
        }
    }
}
