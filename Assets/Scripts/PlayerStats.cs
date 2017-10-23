using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int currentLevel;
	public int currentExp;
	public int[] toLevelUp;
	public int nextExp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentExp >= toLevelUp [currentLevel]) {
			currentLevel ++;
		}

		nextExp = toLevelUp [currentLevel];
	}

	public void AddExperience(int experience) {
		currentExp += experience;
	}

	public int getNextExp() {
		return nextExp;
	}
}
