using UnityEngine;
using System.Collections;

public class Arme : Stuff {

	public	float	lvlRequired;
	public	float	force;
	public	float	agi;
	public	float	con;
	public	float	speed;
	public 	float	damageMin;
	public 	float	damageMax;

	private	string	rangName;
	
	protected override void Start () {
		base.Start ();
		int tmp = Random.Range (1, rareRange);
		force *= tmp + GameManager.gm.level;
		agi *= tmp + GameManager.gm.level;
		con *= tmp + GameManager.gm.level;
		damageMin *= tmp + GameManager.gm.level;
		damageMax *= tmp + GameManager.gm.level;
		rangName = rareName [tmp];
		if (tmp - 1 >= 0 && transform.root.tag != "Enemy") {
			ParticleSystem go = (ParticleSystem)Instantiate (rareParticle [tmp - 1], transform.position, Quaternion.identity);
			go.gameObject.transform.SetParent(gameObject.transform);
		}
	}


	void EquipmentChange(GameObject go) {
		Debug.Log (go);
	}
}
