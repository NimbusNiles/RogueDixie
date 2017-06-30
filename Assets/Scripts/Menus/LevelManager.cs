using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private GameObject player;

    public void Awake() {
        player = FindObjectOfType<PlayerHealth>().gameObject;
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
}
