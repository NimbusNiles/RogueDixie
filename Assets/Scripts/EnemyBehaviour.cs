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

    void FixedUpdate () {
        CheckAggro();
	}

    void CheckAggro()
    {
        Vector2 posDelta = player.transform.position - transform.position;
        float distanceToPlayer = posDelta.magnitude;

        if (distanceToPlayer <= aggroRange)
        {
            Vector2 directionToPlayer = posDelta.normalized;
            Vector2 velocity = directionToPlayer * speed;
            transform.Translate(velocity * Time.fixedDeltaTime);
        }
        
    }
}
