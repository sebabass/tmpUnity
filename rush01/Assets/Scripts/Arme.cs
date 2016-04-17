using UnityEngine;
using System.Collections;

public class Arme : Stuff {

	public	float	lvlRequired;

	public	float	forceMin;
	public	float	forceMax;
	public	float	force;

	public	float	agiMin;
	public	float	agiMax;
	public	float	agi;

	public	float	conMin;
	public	float	conMax;
	public	float	con;

	public	float	damageMin;
	public	float	damageMax;
	public	float	damage;

	public	float	speedMin;
	public	float	speedMax;
	public	float	speed;

	private	string	rangName;

	void Start () {
		force = Random.Range (forceMin, forceMax) * rareRange;
		agi = Random.Range (agiMin, agiMax) * rareRange;
		con = Random.Range (conMin, conMax) * rareRange;
		damage = Random.Range (damageMin, damageMax) * rareRange;
		speed = Random.Range (speedMin, speedMax) * rareRange;
		rangName = rareName [rareRange];
		//Instantiate (rareParticle [rareRange], transform.position, Quaternion.identity);
	}

}
