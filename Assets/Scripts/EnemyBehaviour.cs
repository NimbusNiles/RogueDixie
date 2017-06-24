using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private Player player;
    private float aggroRange;
    private float speed;
    private float recoilSpeed;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        speed = 3f;
        aggroRange = 5f;
        recoilSpeed = 2f;
    }

    void Update () {
        CheckAggro();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Health>().GetDamage(20f);
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
            transform.Translate(directionToPlayer * - recoilSpeed);
        }
    }

    void CheckAggro()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 myPos = transform.position;
        Vector2 posDelta = playerPos - myPos;
        float distanceToPlayer = posDelta.magnitude;

        if (distanceToPlayer <= aggroRange)
        {
            Debug.Log("Aggro'd");
            Vector2 directionToPlayer = posDelta.normalized;
            Vector2 velocity = directionToPlayer * speed;
            transform.Translate(velocity * Time.deltaTime);
        }
        
    }
}
