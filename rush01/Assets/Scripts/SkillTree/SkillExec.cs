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
	}
}
