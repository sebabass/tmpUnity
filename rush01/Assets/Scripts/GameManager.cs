using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public GameManager	gm;
	public Player				player;
	public int					level = 1;

	void Awake () {
		if (gm == null)
			gm = this;
	}
	
	void Start () {
		this.player = GameObject.FindGameObjectWithTag ("Player").transform.GetComponent<Player>();
	}

	public void LevelUp() {
		Debug.Log ("LEVEL UP! (" + this.level + ")");
		this.level++;
	}
}
