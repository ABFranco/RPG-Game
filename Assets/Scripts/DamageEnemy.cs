using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {

	public int damageToGive;
	public GameObject damageBurst;
	public Transform hitPoint;
	public GameObject damageNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy (damageToGive);
			// blank variable var
			var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
	}
}
