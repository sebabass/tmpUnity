using UnityEngine;
using System.Collections;

public enum skillType {
	time,resource
}


public class SkillExec : MonoBehaviour {

	[SerializeField] protected 		skillType	 	_type;
	[SerializeField] protected 		float		 	_reloadTime;
	[HideInInspector] protected 	float		 	_execTime;
	[HideInInspector] protected		SkillAnimation	_skillAnnimation;

	[SerializeField] public 		Character		 impacted;
	[SerializeField] protected 		float		 	_life;
	[SerializeField] protected 		float		 	_force;

	// Use this for initialization
	void Start () {
		this._skillAnnimation = GetComponent<SkillAnimation>();
		this._execTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	public void animate () {
		if ( this._skillAnnimation == null )
			return ;
		this._skillAnnimation.instantiateAnimation();
	}

	public void exec() {
		if ( this._type == skillType.time && this._execTime > Time.fixedTime )
			return ;
		this.animate();
		this._execTime = Time.fixedTime + this._reloadTime;

		if ( this.impacted == null )
			return ;
		this.impacted.force += this._force;
		this.impacted.ModifyHealth( this._life );
	}

	public GameObject getImpacted() {
		if ( this._skillAnnimation._positionOn == initPositionOn.mouse ) {
			RaycastHit hit;
			Ray rayPos; rayPos = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayPos, out hit, 100)) {
				return hit.collider.gameObject;
			}
			return null;
		}
		return GameManager.gm.player.gameObject;
	}

	public void setImpacted( GameObject obj ) {
		Character chara = (Character)obj.GetComponent<Character>();
		if ( chara == null )
			return ;
		this.impacted = chara;
	}
}
