using UnityEngine;
using System.Collections;

public class Arme : Stuff {

	public	float	lvlRequired;
	public	float	force;
	public	float	agi;
	public	float	con;
	public	float	damage;
	public	float	speed;

	private	string	rangName;

	protected override void Start () {
		base.Start ();
		Debug.Log ("range: " +rareRange);
		int tmp = Random.Range (1, rareRange);
		force *= tmp + GameManager.gm.level;
		agi *= tmp + GameManager.gm.level;
		con *= tmp + GameManager.gm.level;
		damage *= tmp + GameManager.gm.level;
		rangName = rareName [tmp];
		Debug.Log (rareName[tmp]);
		if (tmp - 1 >= 0 && transform.root.tag != "enemy") {
			Debug.Log ("tmp: " +  (tmp - 1));
			ParticleSystem go = (ParticleSystem)Instantiate (rareParticle [tmp - 1], transform.position, Quaternion.identity);
			go.gameObject.transform.SetParent(gameObject.transform);
		}
	}

}
