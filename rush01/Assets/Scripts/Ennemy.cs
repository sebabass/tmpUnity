using UnityEngine;
using System.Collections;

public class Ennemy : Character {

	protected float radiusPursuit = 10.0f;
	protected Animator _anim;
	protected float	expGain;

	protected Transform positionPlayer;
	private bool animAttack = false;


	protected override void Awake () {
		base.Awake ();
		_anim = GetComponent<Animator> ();
	}

	void Start () {
		expGain = 10f;
	}
	
	void Update () {
		//Debug.Log (_anim.GetCurrentAnimatorClipInfo(0));
		if (health <= 0 && !dead)
			Die ();
		if (dead)
			transform.Translate (Vector3.down * Time.deltaTime);
		else {
			OnEnemy();
		}
	}

	void Detection() {
		Collider[] hitColliders1 = Physics.OverlapSphere (transform.position, radiusPursuit);
		for (int i = 0; i < hitColliders1.Length; i++) {
			if (hitColliders1[i].CompareTag("player")) {
				currentTarget = hitColliders1 [i].gameObject;
				if (Vector3.Distance(hitColliders1[i].transform.position, this.transform.position) > 2.5f) {
					Run();
				}
			}
		}
	}

	void OnEnemy() {
		this.Detection ();
		if (navMesh && navMesh.remainingDistance <= navMesh.stoppingDistance) {
			if (!navMesh.hasPath || Mathf.Abs (navMesh.velocity.sqrMagnitude) < float.Epsilon)
			{
				_anim.SetBool ("isRunning", false);
				Attack();
			}
		}
	}

	protected override void Die() {
		dead = true;
		_anim.SetBool ("isAttack", false);
		_anim.SetBool ("isDeath", true);
		StartCoroutine (ClearZombie ());
	}

	void Attack () {
		transform.LookAt(currentTarget.transform.position);
		_anim.SetTrigger("isAttack");
	}

	void  Run () {
		this._anim.ResetTrigger ("isAttack");
		this.navMesh.destination = this.currentTarget.transform.position;
		this.navMesh.Resume();
		//if (this.navMesh.hasPath) {
			this._anim.SetBool ("isRunning", true);
		//}
		/*
		if (navMesh) {
			transform.LookAt(currentTarget.transform.position);
			navMesh.destination = currentTarget.transform.position;
			navMesh.Resume ();
			_anim.SetBool ("isRunning", true);
		}*/
	}

	IEnumerator ClearZombie () {
		GameManager.gm.player.isAttack = false;
		GameManager.gm.player.currentTarget = null;
		//GameManager.gm.player.ModifyExperience (expGain);
		//popPotion ();
		yield return new WaitForSeconds (4.0f);
		navMesh.enabled = false;
		yield return new WaitForSeconds (1.0f);
		GameObject.Destroy (gameObject);
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, radiusPursuit);
	}

}
