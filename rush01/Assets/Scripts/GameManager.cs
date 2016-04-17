using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public GameManager	gm;
	public	GameObject			camera;
	public	Player			player;
	public Zombie 				onEnemy;

	void Awake () {
		if (gm == null)
			gm = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
