using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Warrior : MonoBehaviour {

    public float maxRage;
    public float rageCooldown;
    public float rageDegen;
    public string startingWeapon;

    private float currentRage = 0f;
    private float rageCooldownTimer;
    private Image HUDRageBarImage;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        
        GetComponent<InventoryController>().GiveItem(startingWeapon);
    }

    public void AddRage(float amount) {
        currentRage = Mathf.Clamp(currentRage + amount, 0f, maxRage);
        rageCooldownTimer = 0f;
        UpdateRageBar();
    }

    public void SubstractRage(float amount) {
        currentRage = Mathf.Clamp(currentRage - amount, 0f, maxRage);
        UpdateRageBar();
    }

    private void Update() {
        rageCooldownTimer += Time.deltaTime;

        if (rageCooldownTimer >= rageCooldown) {
            SubstractRage(rageDegen * Time.deltaTime);
        }
    }

    void UpdateRageBar() {
        HUDRageBarImage.fillAmount = currentRage / maxRage;
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += FindObjects;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= FindObjects;
    }

    void FindObjects(Scene scene, LoadSceneMode mode) {
        HUDRageBarImage = GameObject.Find("ResourceFull").GetComponent<Image>();
        UpdateRageBar();
    }
}
