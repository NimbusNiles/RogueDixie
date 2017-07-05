using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoins : MonoBehaviour {

    public GameObject coinPrefab;
    
    public void Drop(GameObject enemy) {
        for(int i = 0; i < Random.Range(1, 4); i++) {

            GameObject obj = CoinPool.instance.AcquireCoin();
            if (obj == null) {
                Debug.Log("Trying to drop a coin but none was Acquired from CoinPool");
                return;
            }

            obj.transform.position = transform.position + new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), 0);
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
        }
    }
}
