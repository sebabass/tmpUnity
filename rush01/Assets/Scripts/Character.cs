using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {

	public 		float 			force, agility, constitution, armor;
	//public 		Renderer 		rend;
	//public 		GameObject 		ragdoll;

	[HideInInspector]
	public GameObject			currentTarget;
	public Arme					arme;

	protected 	NavMeshAgent	navMesh;	
	protected 	float 			health,mana;
	protected 	float 			maxHealth,maxMana;
	protected 	bool 			dead = false;
	protected 	int 			level = 1;
	protected 	Color 			color;
	public	bool			isAttack;
	


	// Use this for initialization
	protected virtual void Awake () {
		health = 100;
		mana = 100;
		maxHealth = health;
		maxMana = mana;
		navMesh = GetComponent<NavMeshAgent> ();
	}

	public void ModifyHealth (float amount) {
		if( dead ) 
			return;
		health += amount;
		if( health < 0 ) {
			health = 0;
			Die();
		}
		else if( health > maxHealth ) 
			health = maxHealth;
		if( amount > 0 ) {
			Debug.Log("PRENDRE POTION");
			/*GameObject potion = (GameObject)Instantiate(healthPotion,potionHolder.position,Quaternion.identity);
			potion.transform.SetParent(potionHolder);
			potion.transform.localRotation = Quaternion.Euler(rotation);
			StartCoroutine("DrinkPotion",potion);*/
		}
		else {
			if( health > 0 )
				StartCoroutine( "GetHit" );
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
		//ragdoll.SetActive( true );
		//ragdoll.GetComponent<AudioSource>().volume = 0.5f;
		//ragdoll.GetComponent<AudioSource>().PlayOneShot( deadSound );
		gameObject.SetActive( false );
		dead = true;
	}

	public bool isDead () {
		return dead;
	}

	protected void receiveDamage(float damage, float agiAdverse) {
		if (Random.Range (1, 101) <= 75 + agiAdverse - this.agility) {
			damage *= (1 - this.armor / 200);
			ModifyHealth(-damage);
		}
	}

	public float DamageAttackMeele() {
		return (Random.Range (this.arme.damageMin, this.arme.damageMax + 1) + this.force);
	}

	/*void OnTriggerEnter (Collider col) {
		if (col.CompareTag ("weapon")) {
			Debug.Log (this.name + " touched by " + col.name);
			//receiveDamage(attacker.DamageAttackMeele(), attacker.agility);
		}
	}*/
}
