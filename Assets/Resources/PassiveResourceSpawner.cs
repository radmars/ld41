using System.Collections;
using UnityEngine;

public class PassiveResourceSpawner : MonoBehaviour {

	public Resource resourceToSpawn;
	public float spawnSeconds = 2.5f;
	public float spawnRadius = 0.2f;

	void Awake() {
		StartCoroutine(SpawnStuff());
	}

	IEnumerator SpawnStuff() {
		while(true) {
			yield return new WaitForSeconds(spawnSeconds);
			var spawnPos = new Vector3(
				transform.position.x + Random.Range(-spawnRadius, spawnRadius),
				transform.position.y + Random.Range(-spawnRadius, spawnRadius),
				transform.position.z
			);
			Instantiate(resourceToSpawn, spawnPos, transform.rotation);
		}
	}
}
