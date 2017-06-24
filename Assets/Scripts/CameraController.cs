using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>().gameObject;
        offset.x = 1f / 32f;
        offset.y = 1f / 32f;
        offset.z = -10f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
    }
}
