using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject floorTile;
    public GameObject wallTile;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private GameObject mapSize;
    private GameObject mapTiles;

    // Use this for initialization
    void Start () {

        mapSize = FindObjectOfType<MapSize>().gameObject;

        xMin = Mathf.Round( mapSize.transform.position.x - mapSize.transform.localScale.x / 2 );
        xMax = Mathf.Round( mapSize.transform.position.x + mapSize.transform.localScale.x / 2 );
        yMin = Mathf.Round( mapSize.transform.position.y - mapSize.transform.localScale.y / 2 );
        yMax = Mathf.Round( mapSize.transform.position.y + mapSize.transform.localScale.y / 2 );

        // Get parent gameobject
        mapTiles = GameObject.Find("MapTiles");
        if (!mapTiles) {
            mapTiles = new GameObject("MapTiles");
            mapTiles.transform.parent = GameObject.Find("Map").gameObject.transform;

            GenerateFloor();
            GenerateWall();
        }

	}
	
    void GenerateFloor() {
        for (float x = xMin; x <= xMax; x++) {
            for(float y = yMin; y <= yMax; y++) {
                PlaceTileAtPosition(x, y, floorTile);
            }
        }
    }

    void GenerateWall() {
        for(float x = xMin -1; x <= xMax + 1; x++) {
            PlaceTileAtPosition(x, yMin - 1f, wallTile);
            PlaceTileAtPosition(x, yMax + 1f, wallTile);
        }
        for (float y = yMin - 1; y <= yMax + 1; y++) {
            PlaceTileAtPosition(xMin - 1f, y, wallTile);
            PlaceTileAtPosition(xMax + 1f, y, wallTile);
        }
    }

    void PlaceTileAtPosition(float x, float y, GameObject tileObject) {
        Vector2 tilePosition = new Vector2(x, y);
        GameObject tile = Instantiate(tileObject, tilePosition, Quaternion.identity) as GameObject;
        tile.transform.parent = mapTiles.transform;
        tile.GetComponent<SpriteRenderer>().sortingLayerName = "MapTiles";
    }
}
