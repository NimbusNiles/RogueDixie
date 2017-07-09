using UnityEngine;
using System.Collections;
using System;

public class NewMapGenerator : MonoBehaviour {

    public GameObject floorTile;
    public GameObject floorTile2;
    public GameObject floorTile3;
    public GameObject wallTile;

    public string seed;
    public bool useRandomSeed = true;
    public int smoothIterations;

    [Range(0, 100)]
    public int randomFillPercent;
    public int borderSize;
    public int erosionSize;
    
    private int[,] map;
    private int[,] tempMap;
    private int width;
    private int height;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private GameObject mapSize;
    private GameObject mapTiles;
    private GameObject tileObject;

    void Start () {

        mapSize = FindObjectOfType<MapSize>().gameObject;

        width = (int)(mapSize.transform.localScale.x);
        height = (int)(mapSize.transform.localScale.y);

        xMin = Mathf.Round( mapSize.transform.position.x - mapSize.transform.localScale.x / 2 );
        xMax = Mathf.Round( mapSize.transform.position.x + mapSize.transform.localScale.x / 2 );
        yMin = Mathf.Round( mapSize.transform.position.y - mapSize.transform.localScale.y / 2 );
        yMax = Mathf.Round( mapSize.transform.position.y + mapSize.transform.localScale.y / 2 );

        // Get parent gameobject
        mapTiles = GameObject.Find("MapTiles");
        if (!mapTiles) {
            mapTiles = new GameObject("MapTiles");
            mapTiles.transform.parent = GameObject.Find("Map").gameObject.transform;

            GenerateMap();
            InstantiateTiles();

        }
	}

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Destroy(mapTiles);

            mapTiles = new GameObject("MapTiles");
            mapTiles.transform.parent = GameObject.Find("Map").gameObject.transform;

            GenerateMap();
            InstantiateTiles();
        }
    }

    void GenerateMap() {
        map = new int[width, height];
        RandomFillMap();                                                                        //Map array is filled with 0's, 1's and 2's

        for (int i = 0; i < smoothIterations; i++) {
            tempMap = new int[width, height];
            SmoothMap();                                                                        //Map array's values are smoothed to nearest neighbours
        }

        ErodeMap();
    }

    void RandomFillMap() {
        if (useRandomSeed) {
            seed = DateTime.Now.Ticks.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {

                int distanceToEdgeX = Mathf.Min(x, width - x);
                int distanceToEdgeY = Mathf.Min(y, height - y);

                float distanceToEdge = (float)Mathf.Min(distanceToEdgeX, distanceToEdgeY) / (float)borderSize;

                float checkPercent = Mathf.Lerp(0, randomFillPercent, distanceToEdge);

                if (x == 0 || x == width - 1 || y == 0 || y == height - 1) {
                    map[x, y] = 0;                                                              //Creates (lava) border
                } else {
                    map[x, y] = (pseudoRandom.Next(0, 100) < checkPercent) ? 1 : 0;
                }
            }
        }
    }

    void SmoothMap() {
        for (int x = 1; x < width -1; x++) {
            for (int y = 1; y < height -1; y++) {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);
                if (map[x, y] == 2) {
                    tempMap[x, y] = 2;
                } else if (neighbourWallTiles > 3) {
                    tempMap[x, y] = 1;
                } else if (neighbourWallTiles < 3) {
                    tempMap[x, y] = 0;
                }
            }
        }

        map = tempMap;

    }

    void ErodeMap() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if(map[x, y] == 1) {
                    for (int neighbourX = x - erosionSize; neighbourX <= x + erosionSize; neighbourX++) {
                        for (int neighbourY = y - erosionSize; neighbourY <= y + erosionSize; neighbourY++) {
                            if (neighbourX != x || neighbourY != y) {
                                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
                                    if (map[neighbourX, neighbourY] == 0) {
                                        map[x, y] = 2;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    int GetSurroundingWallCount(int gridX, int gridY) {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++) {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++) {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {  //Prevent checking off-grid coords
                    if (neighbourX != gridX || neighbourY != gridY) {                                   //Prevent counting the focused coord as a neighbour
                        wallCount += map[neighbourX, neighbourY];
                    }
                } else {
                    wallCount++;
                }
            }
        }
        return wallCount;
    }

    void InstantiateTiles() {
        if (map != null) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    PlaceTileAtPosition(Mathf.RoundToInt(x - .5f * mapSize.transform.localScale.x + mapSize.transform.position.x), Mathf.RoundToInt(y - .5f * mapSize.transform.localScale.y + mapSize.transform.position.y), map[x, y]);
                }
            }
        }
    }
    
    void PlaceTileAtPosition(int x, int y, int tileIndex) {
        Vector2 tilePosition = new Vector2(x, y);
        if (tileIndex == 0) {
            tileObject = floorTile;
        } else if(tileIndex == 1) {
            tileObject = floorTile2;
        }else if (tileIndex == 2) {
            tileObject = floorTile3;
        }
        GameObject tile = Instantiate(tileObject, tilePosition, Quaternion.identity) as GameObject;
        tile.transform.parent = mapTiles.transform;
        tile.GetComponent<SpriteRenderer>().sortingLayerName = "MapTiles";
        tile.layer = LayerMask.NameToLayer("Obstacles");
    }
}
