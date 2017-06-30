using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warrior : MonoBehaviour {

    public float maxRage;
    public float rageCooldown;
    public float rageDegen;

    private float currentRage = 0f;
    private float rageCooldownTimer;
    private Image HUDRageBarImage;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        HUDRageBarImage = GameObject.Find("ResourceFull").GetComponent<Image>();
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
}
