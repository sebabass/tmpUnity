using UnityEngine;
using System.Collections;

public class Enemy : Character {

	protected float radiusPursuit = 10.0f;
	protected float	expGain;
	protected Transform positionPlayer;

	protected override void Awake () {
		base.Awake ();
		_anim = GetComponent<Animator> ();
	}

	protected override void Start () {
		base.Start ();
		expGain = 100f;
	}
	
	protected void Update () {
		if (this.health <= 0 && !this._dead)
			Die ();
		if (this._dead)
			transform.Translate (Vector3.down * Time.deltaTime);
		else {
			this.OnEnemy();
		}
	}

	public void UpdateCaracs() {
		this.agility += this.agility * 0.15f * (float)(GameManager.gm.level - 1);
		this.armor += this.armor * 0.15f * (float)(GameManager.gm.level - 1);
		this.constitution += this.constitution * 0.15f * (float)(GameManager.gm.level - 1);
		this.force += this.force * 0.15f * (float)(GameManager.gm.level - 1);
		this.health = this.constitution * 5f;
	}

	void Detection() {
		Collider[] hitColliders1 = Physics.OverlapSphere (this.transform.position, this.radiusPursuit);
		for (int i = 0; i < hitColliders1.Length; i++) {
			if (hitColliders1[i].CompareTag("Player")) {
				this.currentTarget = hitColliders1 [i].gameObject;
				if (!this.TargetIsCloseToMe())
					this.Run();
			}
		}
	}

	void OnEnemy() {
		this.Detection ();
		if (this.currentTarget && this.TargetIsCloseToMe()) {
			this._anim.SetBool ("isRunning", false);
			this.Attack();
		}
	}

	protected override void Die() {
		base.Die ();
		StartCoroutine (ClearZombie ());
	}

	void  Run () {
		this._anim.ResetTrigger ("isAttack");
		this._agent.destination = this.currentTarget.transform.position;
		this._agent.Resume();
		if (this._agent.hasPath) {
			this._anim.SetBool ("isRunning", true);
		}
	}

	IEnumerator ClearZombie () {
		GameManager.gm.player.ModifyExperience (expGain);
		yield return new WaitForSeconds (4.0f);
		this._agent.enabled = false;
		yield return new WaitForSeconds (1.0f);
		GameObject.Destroy (this.gameObject);
	}

}