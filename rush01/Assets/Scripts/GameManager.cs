using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public GameManager	gm;
	public Player				player;
	public int					level = 1;
	public GameObject			levelUpParticle;
	public int					competencePoints;

	public GameObject[]			lootPotions;
	public GameObject[]			lootWeapons;

	void Awake () {
		if (gm == null)
			gm = this;
	}
	
	void Start () {
		this.player = GameObject.FindGameObjectWithTag ("Player").transform.GetComponent<Player>();
		this.competencePoints = 0;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.L)) {
			this.LevelUp();
		}
	}

	public void LevelUp() {
		this.player.LevelUp ();
		this.competencePoints += 5;
		Debug.Log ("LEVEL UP! (" + this.level + ")");
		StartCoroutine (coLevelUp ());
		this.level++;
	}

	IEnumerator coLevelUp() {
		GameObject levelParticle = Instantiate(this.levelUpParticle, this.player.transform.position, this.player.transform.rotation) as GameObject;
		levelParticle.transform.parent = GameManager.gm.player.transform;
		levelParticle.transform.Rotate (Vector3.right, -90f);
		yield return new WaitForSeconds(3f);
		GameObject.Destroy (levelParticle);
	}

	public void Drop(Vector3 pos) {
		if (Random.Range (0, 5) == 0) {
			int potion = Random.Range (0, 4);

			if (potion == 0) {
				Instantiate (this.lootPotions [Random.Range (0, this.lootPotions.Length)], pos, Quaternion.identity);
			} else {
				Instantiate (this.lootWeapons [Random.Range (0, this.lootWeapons.Length)], pos, Quaternion.identity);
			}
		}
	}
	
}