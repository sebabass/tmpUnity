using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {


	public AudioSource	die_audio;
	public AudioSource	attack_audio;

	public float 		health;
	public float		mana;

	public float 		force;
	public float		agility;
	public float		constitution;
	public float		armor;

	public Arme				arme;

	public bool				isAttack;

	protected NavMeshAgent	_agent;
	protected Animator		_anim;
	
	protected bool			_isAttacking;
	protected Vector3		_currentTargetPosition;
	protected float 		_maxHealth;
	protected float			_maxMana;
	protected bool 			_dead = false;
	protected Color 		_color;
	protected bool			_animAttack;

	[HideInInspector]public GameObject		currentTarget;

	public float GetMaxHealth () {
		return (_maxHealth);
	}

	public float GetMaxMana () {
		return (_maxMana);
	}
	// Use this for initialization
	protected virtual void Awake () {
		this.health = this.constitution * 5;
		this.mana = 100;
		this._maxHealth = this.health;
		this._maxMana = this.mana;
	}

	protected virtual void Start() {
		this._agent = this.GetComponent<NavMeshAgent> ();
		this._anim = this.GetComponent<Animator> ();
		StartCoroutine (coRegenHP ());
		StartCoroutine (coRegenMana ());
	}


	public bool IsDead() {
		if (this.health <= 0 || this._dead)
			return (true);
		return (false);
	}

	public void ModifyHealth (float amount) {
		if (this._dead)
			return;
		this.health += amount;
		if (this.health < 0) {
			this.health = 0;
			this.Die();
		}
		else if (this.health > this._maxHealth) 
			this.health = this._maxHealth;
	}

	public void ModifyMana (float amount) {
		if (this._dead)
			return;
		this.mana += amount;
		if (this.mana < 0) {
			this.mana = 0;
		}
		else if (this.health > this._maxHealth) 
			this.mana = this._maxMana;
	}

	public virtual void Die() {
		this._anim.SetBool ("isAttack", false);
		this._anim.SetBool ("isRunning", false);
		this._anim.SetBool ("isDeath", true);
		this._dead = true;
		die_audio.Play ();
	}

	public void receiveDamage(float damage, Character oppenent) {
//		Debug.Log (this.name + " recive " + damage + " damage");
		if (Random.Range (1, 101) <= 75 + oppenent.agility - this.agility) {
			damage *= (1 - this.armor / 200);
			this.ModifyHealth(-damage);
		}
	}

	public float DamageAttackMeele() {
		return (Random.Range (this.arme.damageMin, this.arme.damageMax) + this.force);
	}

	protected virtual void Attack () {
		this.transform.LookAt(this.currentTarget.transform.position);
		if (!this._animAttack)
			StartCoroutine (oneAttack ());
	}
	
	IEnumerator oneAttack () {
		this._anim.SetTrigger ("isAttack");
		this._animAttack = true;
		this.currentTarget.transform.GetComponent<Character> ().receiveDamage (this.DamageAttackMeele (), this);
		yield return new WaitForSeconds (this.arme.speed);
		this._animAttack = false;

		attack_audio.Play ();
	}

	IEnumerator coRegenHP() {
		while (true) {
			this.ModifyHealth(this._maxHealth / 120f);
			yield return new WaitForSeconds(1f);
		}
	}

	IEnumerator coRegenMana() {
		while (true) {
			this.ModifyMana(this._maxMana / 120f);
			yield return new WaitForSeconds(1f);
		}
	}

	public bool TargetIsAlive() {
		return (this.currentTarget && this.currentTarget.transform.GetComponent<Character> () && !this.currentTarget.transform.GetComponent<Character> ().IsDead ());
	}

	public bool TargetIsCloseToMe() {
		if (this.currentTarget && Vector3.Distance (this.currentTarget.transform.position, this.transform.position) > this._agent.stoppingDistance)
			return (false);
		return (true);
	}

}
