using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour {

    public static CoinPool instance;
    public GameObject coin;
    public int pooledAmount = 15;
    public bool willGrow = true;

    public List<GameObject> coins;

    private void Awake() {
        instance = this;
    }

    void Start () {
        coins = new List<GameObject>();
        for(int i =0; i < pooledAmount; i++) {
            GameObject obj = (GameObject)Instantiate(coin);
            obj.SetActive(false);
            coins.Add(obj);
        }
	}

    public GameObject AcquireCoin() {
        for(int i = 0; i < coins.Count; i++) {
            if (!coins[i].activeInHierarchy) {
                return coins[i];
            }
        }

        if (willGrow) {
            GameObject obj = (GameObject)Instantiate(coin);
            obj.SetActive(false);
            coins.Add(obj);
            return obj;
        }

        return null;
    }

}
