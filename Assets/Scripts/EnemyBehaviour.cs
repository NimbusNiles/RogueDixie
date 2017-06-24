using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private Player player;
    private float aggroRange;
    private float speed;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        speed = 3f;
        aggroRange = 5f;
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
        Debug.Log(distanceToPlayer);

        if (distanceToPlayer <= aggroRange)
        {
            Debug.Log("Aggro'd");
            Vector2 directionToPlayer = posDelta.normalized;
            Vector2 velocity = directionToPlayer * speed;
            transform.Translate(velocity * Time.deltaTime);
        }
        
    }
}
