using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour {

    public static float totalTimeElapsed;

    private Text text;
    private bool isTicking;

    private void OnEnable() {
        if (FindObjectOfType<Boss>()) {
            SceneManager.sceneLoaded += StartTicking;
        }
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= StartTicking;
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        totalTimeElapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isTicking) {
            totalTimeElapsed += Time.deltaTime;
            UpdateTimeDisplay();
        }
	}

    void UpdateTimeDisplay() {
        string minutes = Mathf.Floor(totalTimeElapsed / 60).ToString("00");
        string seconds = (totalTimeElapsed % 60).ToString("00");

        text.text = (minutes + ":" + seconds);
    }

    public void StartTicking(Scene scene, LoadSceneMode mode) {

        text = GameObject.Find("TimeText").GetComponent<Text>();

        if (FindObjectOfType<Boss>()) {
            isTicking = true;
            text.color = Color.red;
        }
        UpdateTimeDisplay();
    }

    public void StopTicking() {
        isTicking = false;
        text.color = Color.green;
    }
}
