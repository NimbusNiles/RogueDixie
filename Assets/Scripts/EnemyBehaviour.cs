using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private Player player;
    private float aggroRange;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update () {
        CheckAggro();
	}

    void CheckAggro()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 myPos = transform.position;
        Vector2 posDelta = playerPos - myPos;
        float distanceToPlayer = posDelta.magnitude;
        if (distanceToPlayer <= aggroRange)
        {
            //Aggro towards player
        }
        
    }
}
