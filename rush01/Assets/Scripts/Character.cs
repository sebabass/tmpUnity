using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {

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
		if( amount > 0 ) {
			Debug.Log("PRENDRE POTION");
			/*GameObject potion = (GameObject)Instantiate(healthPotion,potionHolder.position,Quaternion.identity);
			potion.transform.SetParent(potionHolder);
			potion.transform.localRotation = Quaternion.Euler(rotation);
			StartCoroutine("DrinkPotion",potion);*/
		}
		else {
//			if( health > 0 )
//				StartCoroutine( "GetHit" );
		}
		//healthBar.fillAmount = health / maxHealth;
	}

	/*IEnumerator GetHit() {
		rend.material.color = Color.red;
		//GetComponent<AudioSource>().PlayOneShot( getHitSound );
		yield return new WaitForSeconds( 0.65f );
		rend.material.color = color;
	}*/

	protected virtual void Die() {
		this._anim.SetBool ("isAttack", false);
		this._anim.SetBool ("isDeath", true);
		//ragdoll.SetActive( true );
		//ragdoll.GetComponent<AudioSource>().volume = 0.5f;
		//ragdoll.GetComponent<AudioSource>().PlayOneShot( deadSound );
//		gameObject.SetActive( false );
		this._dead = true;
	}

	public void receiveDamage(float damage, Character oppenent) {
		Debug.Log (this.name + " recive " + damage + " damage");
		if (Random.Range (1, 101) <= 75 + oppenent.agility - this.agility) {
			damage *= (1 - this.armor / 200);
			this.ModifyHealth(-damage);
		}
	}

	public float DamageAttackMeele() {
		return (this.arme.damage + this.force);
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
