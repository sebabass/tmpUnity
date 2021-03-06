﻿using UnityEngine;
using System.Collections;

public class Player : Character {
	
	protected bool			_orderToAction;
	
	public float			cameraX;
	public float			cameraY = 10f;
	public float			cameraZ = -10f;

	public float			xpMax = 400f;
	protected float			_xpCurrent;

	public GameObject		weapons;
	public Arme[]			weapon;

	protected override void Awake() {
		base.Awake ();
		this._xpCurrent = 0f;
		this.weapon = this.weapons.GetComponentsInChildren<Arme> ();
	}

	protected override void Start() {
		base.Start ();
		for (int i = 0; i < this.weapon.Length; i++) {
			this.weapon[i].gameObject.SetActive(false);
		}
	}
	
	protected void Update() {
		this.FixCamera ();
		this.Click ();
		this.CheckWeapon ();
		if (currentTarget) 
			this.HasCurrentTarget ();
	}

	void CheckWeapon() {
		for (int i = 0; i < this.weapon.Length; i++) {
			if (this.weapon[i].gameObject.activeSelf) {
				this.arme = this.weapon[i];
			}
		}
	}

	public float GetCurrentXp() {
		return (this._xpCurrent);
	}

	void HasCurrentTarget() {
		float my_distance = this.currentTarget.tag == "Enemy" ? 2f : 0.5f;
		if ((!this.TargetIsAlive() && Vector3.Distance (this._currentTargetPosition, this.transform.position) < my_distance) || (this.TargetIsAlive() && Vector3.Distance (this.currentTarget.transform.position, this.transform.position) < my_distance) && this._orderToAction) {
			this._anim.SetBool ("isRunning", false);
			Action ();
		}
		else
			Run ();
	}
	
	void FixCamera() {
		Camera.main.transform.position = new Vector3 (this.transform.position.x + this.cameraX, this.transform.position.y + this.cameraY, this.transform.position.z + this.cameraZ);
	}
	
	void Click() {
		Ray rayPos;
		RaycastHit hit;

		if (Input.GetMouseButton (0)) {		
			this._orderToAction = true;

			rayPos = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayPos, out hit, 100)) {
				if (Input.GetMouseButtonDown (0)) {
					this.currentTarget = hit.transform.gameObject;
				}
				if (!TargetIsAlive()) {
					this._currentTargetPosition = hit.point;
				}
			}
		}

		if (!this._anim.GetBool("isRunning") && !this._orderToAction)
			this.currentTarget = null;
		
	}
	
	void Action() {//this function exists because its good if we have others actions than attack
		if (this.arme && this.TargetIsAlive() && this.currentTarget.CompareTag ("Enemy"))
			this.Attack ();
		this._orderToAction = false;
	}
	
	protected virtual void Run() {
		//Debug.Log ("yolo");
		this._anim.ResetTrigger ("isAttack");
		if (TargetIsAlive())
			this._agent.destination = this.currentTarget.transform.position;
		else
			this._agent.destination = this._currentTargetPosition;
		this._agent.Resume();
		if (this._agent.hasPath) {
			this._anim.SetBool ("isRunning", true);
		}
	}

	public void ModifyExperience(float exp) {
		this._xpCurrent += exp;
		if (this._xpCurrent >= this.xpMax) {
			this._xpCurrent -= this.xpMax;
			GameManager.gm.LevelUp();
		}
	}

	public void LevelUp() {
		this.xpMax += GameManager.gm.level * 100;
		this.health += GameManager.gm.level * Random.Range (10, 20);
		this.mana += GameManager.gm.level * Random.Range (5, 10);
		this.force += 1;
		this.agility += 1;
		this.constitution += 1;
		this.armor += 1;
	}


}

/*using UnityEngine;
using System.Collections;

public class Player : Character {
	
	protected bool			_orderToAction;
	
	public float			cameraX;
	public float			cameraY = 10f;
	public float			cameraZ = -10f;

	public float			xpMax = 400f;
	protected float			_xpCurrent;

	protected override void Awake() {
		base.Awake ();
		this._xpCurrent = 0f;
	}
	
	protected void Update() {
		this.FixCamera ();
		this.Click ();
		if (currentTarget) 
			this.HasCurrentTarget ();
	}

	void HasCurrentTarget() {
		float my_distance = this.currentTarget.tag == "Enemy" ? 2f : 0.5f;
		if (Vector3.Distance (this._currentTargetPosition, this.transform.position) < my_distance && this._orderToAction) {
			this._anim.SetBool ("isRunning", false);
			this.Action ();
		}
		else
			this.Run ();
	}
	
	void FixCamera() {
		Camera.main.transform.position = new Vector3 (this.transform.position.x + this.cameraX, this.transform.position.y + this.cameraY, this.transform.position.z + this.cameraZ);
	}
	
	void Click() {
		Ray         rayPos;
		RaycastHit    hit;


		if (Input.GetMouseButton (0)) {		
			this._orderToAction = true;

			rayPos = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayPos, out hit, 100)) {
				if (Input.GetMouseButtonDown (0)) {
					this.currentTarget = hit.transform.gameObject;
				}
				if (TargetIsAlive()) {
					this._currentTargetPosition = this.currentTarget.transform.position;
				} else {
					this._currentTargetPosition = hit.point;
				}
			}
		}

		if (!this._anim.GetBool("isRunning") && !this._orderToAction)
			this.currentTarget = null;
		
	}
	
	void Action() { //this function exists because its good if we have others actions than attack
		if (this.TargetIsAlive() && this.currentTarget.CompareTag ("Enemy"))
			this.Attack ();
		this._orderToAction = false;
	}
	
	protected virtual void Run() {
		this._anim.ResetTrigger ("isAttack");
		this._agent.destination = this._currentTargetPosition;
		this._agent.Resume();
		if (this._agent.hasPath) {
			this._anim.SetBool ("isRunning", true);
		}
	}

	public void ModifyExperience(float exp) {
		this._xpCurrent += exp;
		if (this._xpCurrent >= this.xpMax) {
			this._xpCurrent -= this.xpMax;
			GameManager.gm.LevelUp();
		}
	}
}*/