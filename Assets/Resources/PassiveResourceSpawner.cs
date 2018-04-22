using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveResourceSpawner : MonoBehaviour {

	public Resource resourceToSpawn;
	public int spawnCooldownMax = 500;
	private int spawnCooldown;

	public float spawnRadius = 0.2f;

	void Start() {
		spawnCooldown = spawnCooldownMax;
	}
	
	// Update is called once per frame
	void Update () {
		spawnCooldown--;
		if (spawnCooldown <= 0) {
			Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-spawnRadius, spawnRadius),
				transform.position.y + Random.Range(-spawnRadius, spawnRadius), transform.position.z);
			Instantiate(resourceToSpawn, spawnPos, transform.rotation);
			spawnCooldown = spawnCooldownMax;
		}
	}
}
