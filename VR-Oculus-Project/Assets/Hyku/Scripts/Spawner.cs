using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject target;
	public int quantity = 1;
	private int spawnCount;

	// Use this for initialization
	void Start() {
		InvokeRepeating("Spawn", 1, 1);
	}

	void Update()
	{
		if (spawnCount >= quantity) {
			CancelInvoke("Spawn");
		}
	}

	public void Spawn()
	{
		float x = Random.Range(-4.0f, 4.0f);
		float y = 1;
		float z = Random.Range(-4.0f, 4.0f);
		Instantiate(target, new Vector3(x, y, z), Quaternion.identity);
        spawnCount++;
	}
}