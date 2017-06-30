using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour {

    public float splashTime = 2f;
    [Tooltip("Splash screen time in seconds")]
    
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > splashTime) {
            levelManager.LoadNextLevel();
        }
	}
}
