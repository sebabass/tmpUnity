using UnityEngine;
using System.Collections;

public class Player : Character {
	
	//    private    GameObject        _currentTarget;
	private    Vector3        _currentTargetPosition;
	private    bool            _isAttacking;
	//    private    NavMeshAgent    _agent;
	private Animator        _anim;
	private    bool            _orderToAction;
	
	public float            cameraX;
	public float            cameraY = 10f;
	public float            cameraZ = -10f;
	
	void Start() {
		//        _agent = this.GetComponent<NavMeshAgent> ();
		_anim = this.GetComponent<Animator> ();
	}
	
	protected void Update() {
		this.FixCamera ();
		this.Click ();
		if (currentTarget) 
			this.HasCurrentTarget ();
	}
	
	void HasCurrentTarget() {
		float my_distance = currentTarget.tag == "enemy" ? 2f : 0.5f;
		if (Vector3.Distance (_currentTargetPosition, transform.position) < my_distance && _orderToAction) {
			Debug.Log("wesh");
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
			
			rayPos = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayPos, out hit, 100)) {
				this._orderToAction = true;
				if (Input.GetMouseButtonDown (0)) {
					this.currentTarget = hit.transform.gameObject;
				}
				if (this.currentTarget.tag != "enemy")
					this._currentTargetPosition = hit.point;
				else
					this._currentTargetPosition = this.currentTarget.transform.position;
			}
		}
		if (!_anim.GetBool("isRunning") && !_orderToAction)
			currentTarget = null;
		
	}
	
	void Action() {//this function exists because its good if we have others actions than attack
		if (this.currentTarget.CompareTag ("enemy"))
			Attack ();
		this._orderToAction = false;
	}
	
	void Attack() {
		transform.LookAt (this.currentTarget.transform.position);
		this._anim.SetTrigger ("isAttack");
		//target.GetComponent<Character>().GetHit ();
	}
	
	protected virtual void Run() {
		this._anim.ResetTrigger ("isAttack");
		this.navMesh.destination = this._currentTargetPosition;
		this.navMesh.Resume();
		if (this.navMesh.hasPath) {
			this._anim.SetBool ("isRunning", true);
		}
	}    
}