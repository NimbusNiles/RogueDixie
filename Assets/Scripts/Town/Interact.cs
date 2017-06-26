using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public GameObject innerInventory;
    public GameObject outerInventory;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private GameObject inventorySize;
    public GameObject inventoryTiles;

    private void AccessInventory() {
        Debug.Log("Open Shop");
        inventorySize = FindObjectOfType<InventorySize>().gameObject;

        xMin = Mathf.Round(inventorySize.transform.position.x - inventorySize.transform.localScale.x / 2);
        xMax = Mathf.Round(inventorySize.transform.position.x + inventorySize.transform.localScale.x / 2);
        yMin = Mathf.Round(inventorySize.transform.position.y - inventorySize.transform.localScale.y / 2);
        yMax = Mathf.Round(inventorySize.transform.position.y + inventorySize.transform.localScale.y / 2);

        inventoryTiles = GameObject.Find("inventoryTiles");
        if (!inventoryTiles)
        {
            inventoryTiles = new GameObject("inventoryTiles");
            inventoryTiles.transform.parent = GameObject.Find("Inventory Manager").gameObject.transform;

            GenerateInner();
            GenerateOuter();
        }

    }

    void GenerateInner()
    {
        for (float x = xMin; x <= xMax; x++)
        {
            for (float y = yMin; y <= yMax; y++)
            {
                PlaceTileAtPosition(x, y, innerInventory);
            }
        }
    }

    void GenerateOuter()
    {
        for (float x = xMin - 1; x <= xMax + 1; x++)
        {
            PlaceTileAtPosition(x, yMin - 1f, outerInventory);
            PlaceTileAtPosition(x, yMax + 1f, outerInventory);
        }
        for (float y = yMin - 1; y <= yMax + 1; y++)
        {
            PlaceTileAtPosition(xMin - 1f, y, outerInventory);
            PlaceTileAtPosition(xMax + 1f, y, outerInventory);
        }
    }

    void PlaceTileAtPosition(float x, float y, GameObject tileObject)
    {
        Vector2 tilePosition = new Vector2(x, y);
        GameObject tile = Instantiate(tileObject, tilePosition, Quaternion.identity) as GameObject;
        tile.transform.parent = inventoryTiles.transform;
        tile.GetComponent<SpriteRenderer>().sortingLayerName = "Features";
        tile.layer = LayerMask.NameToLayer("default");
        tile.GetComponent<SpriteRenderer>().sortingOrder = 5;

    }

    private void CloseInventory()
    {
        Debug.Log("Close Inventory");
        DestroyObject(inventoryTiles);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AccessInventory();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseInventory();
    }



}
