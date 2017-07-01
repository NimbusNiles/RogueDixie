using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [Tooltip("If no player persists from precious scene, a new player of this class is spawned")]
    public GameObject startClass;
    public GameObject startCamera;
    public GameObject startHUD;

    private GameObject player;

    public void Awake() {

        // Check for player
        if (!FindObjectOfType<PlayerHealth>()) {
            player = SpawnPlayer();
        } else {
            player = FindObjectOfType<PlayerHealth>().gameObject;
        }
        // Set player position to zero
        player.transform.position = Vector2.zero;
        player.transform.rotation = Quaternion.identity;
        
    }

    public void LoadNextLevel() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public void LoadLevel(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitRequest() {
        Debug.Log("Quit Requested");
        Application.Quit();
    }

    GameObject SpawnPlayer() {
        return Instantiate(startClass);
    }
}
