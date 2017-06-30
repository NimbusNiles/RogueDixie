using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(int difficulty) {
        // Difficulties: 1 = easy, 2 = normal, 3 = hard
        if (difficulty <= 3 && difficulty >= 1) {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        } else {
            Debug.LogError("Difficulty out of bounds");
        }
    }

    public static int GetDifficulty() {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

}
