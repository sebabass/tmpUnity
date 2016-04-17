using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnerZombie : MonoBehaviour {
	
	/*// Public
	public List<Zombie> zombies = new List<Zombie>();
	public float timeRespawn = 10.0f;
	
	// Private
	private int range;
	private float timeTmp;
	private Zombie zombie;
	
	void Awake () {
		timeTmp = 0;
		zombie = null;
	}
	
	void Start () {
		
		spawnZombie ();
	}
	
	void Update () {
		if (zombie && zombie.isDead ()) {
			zombie = null;
		}
		if (!zombie) {
			timeTmp += Time.deltaTime;
			if (timeTmp >= timeRespawn) {
				timeTmp = 0;
				spawnZombie ();
			}
		}
	}
	
	void spawnZombie () {
		zombie = null;
		int range = Random.Range (0, 2);
		zombie = (Zombie)Instantiate(zombies[range], transform.position, Quaternion.identity);
	}*/
}