﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserCollisionDamage : MonoBehaviour
{
	public GameObject player;
    public GameObject effect;
    public int damage;
 
    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy" || other.tag == "Boss")
        {
			if (player != null) 
				player.SendMessage ("AddPower", 2);
			
			other.SendMessage("ReceiveDamage",damage);

			if (other.tag == "Enemy" && other.GetComponent<EnemyCollisionDamage>().health <= 0f)
				player.SendMessage ("AddScore", other.GetComponent<StatsEnemy> ().deathPoint);

			if (other.tag == "Boss" && other.GetComponent<MiniBossColisionDmg>().health <= 0f)
				player.SendMessage ("AddScore", other.GetComponent<StatsEnemy> ().deathPoint);

			Die();
        }
    }

    void Die()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
