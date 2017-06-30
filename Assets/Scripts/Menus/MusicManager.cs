using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusic;

    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        audioSource = GetComponent<AudioSource>();
        if (levelMusic[scene.buildIndex]) {
            audioSource.clip = levelMusic[scene.buildIndex];
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void SetVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            audioSource.volume = volume;
        } else {
            Debug.LogError("Trying to set volume out of bounds");
        }
    }
}
