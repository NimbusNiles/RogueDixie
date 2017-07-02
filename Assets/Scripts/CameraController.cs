using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Transform mapSize;
    private Camera thisCamera;

    private Vector3 mapPosition;
    private Vector3 mapScale;
    private Vector3 offset;
    private Vector3 camClamp;
    private Vector3 velocity;

    private float camClampMinX;
    private float camClampMinY;
    private float camClampMaxX;
    private float camClampMaxY;

    private float cameraAspect;
    private float cameraSize;

    private float smoothness;

    void Start () {
        player = FindObjectOfType<PlayerMovement>().gameObject;
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
        velocity = Vector3.zero;
        smoothness = 0.09f;                                     //Approximate time camera will take to reach the target. A smaller value will reach the target faster
    }
	
	void FixedUpdate () {
        GetAspect();
        ClampPosition();
        transform.position = Vector3.SmoothDamp(transform.position, camClamp, ref velocity, smoothness);
    }

    void GetAspect() {
        thisCamera.ResetAspect();
        cameraAspect = thisCamera.aspect;
        camClampMinX = mapPosition.x - .5f * mapScale.x + cameraSize * cameraAspect;
        camClampMaxX = mapPosition.x + .5f * mapScale.x - cameraSize * cameraAspect;
    }

    void ClampPosition() {
        camClamp = player.transform.position + offset;
        camClamp.x = Mathf.Clamp(camClamp.x, camClampMinX, camClampMaxX);
        camClamp.y = Mathf.Clamp(camClamp.y, camClampMinY, camClampMaxY);
    }
}
