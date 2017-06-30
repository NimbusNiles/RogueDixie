using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsManager : MonoBehaviour {

    public Slider volumeSlider;

    private LevelManager levelManager;
    private MusicManager musicManager;

    // Use this for initialization
    void Start() {
        levelManager = GetComponent<LevelManager>();
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
    }

    // Update is called once per frame
    void Update() {
        musicManager.SetVolume(volumeSlider.value);
    }

    public void SaveAndReturn() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        levelManager.LoadLevel("00b_Start");
    }

    public void SetDefaults() {
        volumeSlider.value = 0.7f;
    }

}
