using UnityEngine;
using System.Collections;

public class Arme : Stuff {

	public	float	lvlRequired;

	public	float	forceMin;
	public	float	forceMax;
	[HideInInspector]public	float	force;

	public	float	agiMin;
	public	float	agiMax;
	[HideInInspector]public	float	agi;

	public	float	conMin;
	public	float	conMax;
	[HideInInspector]public	float	con;

	public	float	damageMin;
	public	float	damageMax;
	[HideInInspector]public	float	damage;

	public	float	speedMin;
	public	float	speedMax;
	[HideInInspector]public	float	speed;

	private	string	rangName;

	protected override void Start () {
		base.Start ();
		Debug.Log ("range: " +rareRange);
		int tmp = Random.Range (1, rareRange);
		force = Random.Range (forceMin, forceMax) * tmp;
		agi = Random.Range (agiMin, agiMax) * tmp;
		con = Random.Range (conMin, conMax) * tmp;
		damage = Random.Range (damageMin, damageMax) * tmp;
		speed = Random.Range (speedMin, speedMax) * tmp;
		rangName = rareName [tmp];
		Debug.Log (rareName[tmp]);
		if (tmp - 1 >= 0 && transform.root.tag != "enemy") {
			Debug.Log ("tmp: " +  (tmp - 1));
			ParticleSystem go = (ParticleSystem)Instantiate (rareParticle [tmp - 1], transform.position, Quaternion.identity);
			go.gameObject.transform.SetParent(gameObject.transform);
		}
	}

}
