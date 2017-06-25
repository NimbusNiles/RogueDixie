using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Transform mapSize;
    private Vector3 mapPosition;
    private Vector3 mapScale;
    private float cameraSize;
    private Vector3 offset;
    private float camClampMinX;
    private float camClampMinY;
    private float camClampMaxX;
    private float camClampMaxY;
    private Vector3 camClamp;
    private float cameraAspect;

    //TODO: tidy up (e.g. put camera component in a variable), call camera.ResetAspect() to fix camera issues after resizing

	void Start () {
        player = FindObjectOfType<Player>().gameObject;
        mapSize = FindObjectOfType<MapSize>().transform;
        mapPosition = mapSize.position;
        mapScale = mapSize.localScale + new Vector3(3f,3f,0); //compensating for the fact that the tiles lie 3 units outside the MapSize object in both directions
        cameraSize = GetComponent<Camera>().orthographicSize;
        cameraAspect = GetComponent<Camera>().aspect;

        camClampMinX = mapPosition.x - .5f * mapScale.x + cameraSize * cameraAspect;
        camClampMaxX = mapPosition.x + .5f * mapScale.x - cameraSize * cameraAspect;

        camClampMinY = mapPosition.y - .5f * mapScale.y + cameraSize;
        camClampMaxY = mapPosition.y + .5f * mapScale.y - cameraSize;

        offset.x = 1f / 32f;
        offset.y = 1f / 32f;
        offset.z = -10f;
    }
	
	void LateUpdate () {
        camClamp.x = Mathf.Clamp(player.transform.position.x + offset.x, camClampMinX, camClampMaxX);
        camClamp.y = Mathf.Clamp(player.transform.position.y + offset.y, camClampMinY, camClampMaxY);
        camClamp.z = player.transform.position.z + offset.z;
        transform.position = camClamp;
    }
}
