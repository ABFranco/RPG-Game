using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text hpText;
	public PlayerHealthManager playerHealth;

	private static bool uiExists;

	// Use this for initialization
	void Start () {
		if (!uiExists) {
			uiExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		hpText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
	}
}
