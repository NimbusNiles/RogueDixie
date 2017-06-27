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

    void FixedUpdate () {
        CheckAggro();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AttackPlayer();
        }
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

    void AttackPlayer()
    {
        player.GetComponent<Health>().DealDamage(20f);                   //Deal damage to player
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        transform.Translate(-(directionToPlayer * recoilSpeed));        //Give velocity opposite to player's position, i.e. recoil
    }
}
