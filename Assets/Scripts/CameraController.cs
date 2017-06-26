using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Transform mapSize;
    private Camera thisCamera;

    private Vector3 mapPosition;
    private Vector3 mapScale;
    private Vector3 offset;
    private Vector3 camClamp;

    private float camClampMinX;
    private float camClampMinY;
    private float camClampMaxX;
    private float camClampMaxY;

    private float cameraAspect;
    private float cameraSize;

    void Start () {
        player = FindObjectOfType<Player>().gameObject;
        mapSize = FindObjectOfType<MapSize>().transform;
        thisCamera = GetComponent<Camera>();

        mapPosition = mapSize.position;                         //Used as offset
        mapScale = mapSize.localScale + new Vector3(3f,3f,0);   //Extra 3 units padding, compensating for the fact that the tiles lie 1.5 units outside the MapSize object in both directions
        cameraSize = thisCamera.orthographicSize;               //Size of the camera is the -height- in world space units
        cameraAspect = thisCamera.aspect;                       //Using aspect ratio to determine the -width- in world space units

        camClampMinX = mapPosition.x - .5f * mapScale.x + cameraSize * cameraAspect;
        camClampMaxX = mapPosition.x + .5f * mapScale.x - cameraSize * cameraAspect;
        camClampMinY = mapPosition.y - .5f * mapScale.y + cameraSize;
        camClampMaxY = mapPosition.y + .5f * mapScale.y - cameraSize;

        offset.z = -10f;
    }
	
	void LateUpdate () {
        thisCamera.ResetAspect();
        cameraAspect = thisCamera.aspect;

        camClampMinX = mapPosition.x - .5f * mapScale.x + cameraSize * cameraAspect;
        camClampMaxX = mapPosition.x + .5f * mapScale.x - cameraSize * cameraAspect;

        camClamp = (player.transform.position + offset);
        camClamp.x = (int)(Mathf.Clamp(camClamp.x, camClampMinX, camClampMaxX) / 0.03125f) * 0.03125f + 0.015625f;  //Round to nearest 1/32th, add 1/64th
        camClamp.y = (int)(Mathf.Clamp(camClamp.y, camClampMinY, camClampMaxY) / 0.03125f) * 0.03125f + 0.015625f;  //Round to nearest 1/32th, add 1/64th
        transform.position = camClamp;
    }
}
