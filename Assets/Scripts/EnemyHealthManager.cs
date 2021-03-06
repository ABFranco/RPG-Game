﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public int experienceToGive;

	private PlayerStats thePlayerStats;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		thePlayerStats = FindObjectOfType<PlayerStats>();
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			//gameObject.SetActive (false);
			Destroy(gameObject);
			thePlayerStats.AddExperience (experienceToGive);
		}
	}

	public void HurtEnemy(int damage) {
		currentHealth -= damage;
	}

	public void HealEnemy(int heal) {
		currentHealth += heal;
	}

	public void FullHeal() {
		currentHealth = maxHealth;
	}

	public void SetMaxHealth(int newHealth) {
		maxHealth = newHealth;
	}
}
