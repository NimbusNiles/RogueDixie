using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        offset.z = -10f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
    }
}
