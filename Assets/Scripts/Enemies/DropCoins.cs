using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoins : MonoBehaviour {

    public GameObject coinPrefab;
    
    public void Drop() {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
