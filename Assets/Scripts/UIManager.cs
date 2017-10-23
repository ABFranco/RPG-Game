using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text hpText;
	public PlayerHealthManager playerHealth;

	public Slider expBar;
	private PlayerStats stats;
	public Text levelUp;

	private static bool uiExists;

	// Use this for initialization
	void Start () {
		if (!uiExists) {
			uiExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
		stats = GetComponent<PlayerStats> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		hpText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

		expBar.maxValue = stats.getNextExp();
		expBar.value = stats.currentExp;
		levelUp.text =  "Exp: " + stats.currentExp.ToString() + "/" + stats.nextExp.ToString() + "   Lvl: " + stats.currentLevel;
	}
}
