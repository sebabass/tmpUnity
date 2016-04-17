using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerEnemy : MonoBehaviour {
	
	// Public
	public List<Enemy> enemys = new List<Enemy>();
	public float timeRespawn = 10.0f;
	
	// Private
	private float _timeTmp;
	private Enemy _enemy;
	
	void Awake () {
		this._timeTmp = 0;
	}
	
	void Start () {
		SpawnZombie ();
	}
	
	void Update () {
		if (this._enemy && this._enemy.IsDead()) {
			this._enemy = null;
		}
		if (!this._enemy) {
			this._timeTmp += Time.deltaTime;
			if (this._timeTmp >= this.timeRespawn) {
				this._timeTmp = 0;
				SpawnZombie ();
			}
		}
	}
	
	void SpawnZombie () {
		this._enemy = null;
		int range = Random.Range (0, 2);
		this._enemy = (Enemy)Instantiate(this.enemys[range], this.transform.position, Quaternion.identity);
		this._enemy.UpdateCaracs ();
	}
}