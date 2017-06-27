using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public int numberOfEnemies = 1;
    public GameObject zombiePrefab;

    private GameObject enemyParent;
    
	// Use this for initialization
	void Start () {

        enemyParent = GameObject.Find("Enemies");
        if (!enemyParent) {
            Debug.Log("Enemies folder gameobject not present in scene, please make one");
        }

        float minx = -transform.localScale.x;
        float miny = -transform.localScale.y;
        float maxx = transform.localScale.x;
        float maxy = transform.localScale.y;

        for (int ii = 0; ii < numberOfEnemies; ii++) {
            float randomPosX = Random.Range(minx, maxx);
            float randomPosY = Random.Range(miny, maxy);
            Vector3 randomPos = new Vector3(randomPosX, randomPosY);

            GameObject currentEnemy = Instantiate(zombiePrefab, transform.position + randomPos, Quaternion.identity);
            currentEnemy.transform.parent = enemyParent.transform;

        }
	}

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

}
