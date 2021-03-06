﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour {

	public Image health;
	public float hp, maxHp;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		if(enemy.tag == "Enemy")
			hp = enemy.GetComponent<EnemyCollisionDamage> ().health;
		if(enemy.tag == "MiniBoss")
			hp = enemy.GetComponent<MiniBossColisionDmg> ().health;
		if(enemy.tag == "Boss")
			hp = enemy.GetComponent<BossCollisionDamage> ().health;

		if(enemy.tag == "Enemy")
			maxHp = enemy.GetComponent<EnemyCollisionDamage> ().maxHp;
		if(enemy.tag == "MiniBoss")
			maxHp = enemy.GetComponent<MiniBossColisionDmg> ().maxHp;
		if(enemy.tag == "Boss")
			maxHp = enemy.GetComponent<BossCollisionDamage> ().maxHp;
		health.transform.localScale = new Vector2 (hp / maxHp, 1);
	}
}
