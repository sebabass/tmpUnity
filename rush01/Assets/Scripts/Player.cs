using UnityEngine;
using System.Collections;

public class Player : Character {
	
	protected bool			_orderToAction;
	
	public float			cameraX;
	public float			cameraY = 10f;
	public float			cameraZ = -10f;

	public float			xpMax = 400f;
	protected float			xpCurrent;

	protected override void Awake() {
		base.Awake ();
		this.xpCurrent = 0f;
	}
	
	protected void Update() {
		this.FixCamera ();
		this.Click ();
		if (currentTarget) 
			this.HasCurrentTarget ();
	}

	void HasCurrentTarget() {
		float my_distance = currentTarget.tag == "Enemy" ? 2f : 0.5f;
		if ((!TargetIsAlive() && Vector3.Distance (_currentTargetPosition, transform.position) < my_distance) || (TargetIsAlive() && Vector3.Distance (this.currentTarget.transform.position, transform.position) < my_distance) && _orderToAction) {
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
		Ray         rayPos;
		RaycastHit    hit;


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

		if (!_anim.GetBool("isRunning") && !_orderToAction)
			currentTarget = null;
		
	}
	
	void Action() {//this function exists because its good if we have others actions than attack
		if (TargetIsAlive() && this.currentTarget.CompareTag ("Enemy"))
			Attack ();
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
		this.xpCurrent += exp;
		if (this.xpCurrent >= this.xpMax) {
			this.xpCurrent -= this.xpMax;
			GameManager.gm.LevelUp();
		}
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