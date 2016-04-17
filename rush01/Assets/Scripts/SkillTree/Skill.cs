using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill : SkillInformations {
	[SerializeField]  protected		float			_price;
	[SerializeField]  protected		int				_maxLevel;
	[SerializeField]  protected		Skill			_prev;
	[SerializeField]  protected		Skill			_next;
	[SerializeField]  protected		int				_minimumStep;


	[SerializeField] protected		int				_currentLevel;
	[HideInInspector] protected		bool			_owned;
	[HideInInspector] protected		UserSkills		_usersSkills;
	[HideInInspector] protected		SkillExec		_skillScript;

	void		Start() {
		if ( this._usersSkills == null )
			this.UpdateUserSkills();

		this._skillScript = GetComponent<SkillExec>();
	}








	public void						use() {
		this._skillScript.setImpacted( this._skillScript.getImpacted() );
		this._skillScript.exec();
	}

	public void UpdateUserSkills() {
		this._usersSkills = GameObject.Find("UserSkills").GetComponent<UserSkills>();
	}

	public 				List<Skill>	getBranch() {
		List<Skill> list = new List<Skill>();

		Skill current = this;
		while ( current != null ) {
			list.Add( current );
			current = current.GetNextSkill();
		}
		return list;
	}

	public				Skill		GetNextSkill() {
		return this._next;
	}

	public 				bool		Unlock() {
		if ( this._currentLevel >= this._maxLevel ) {
			Debug.LogError("Max level is already reached for this skill.");
			return false;
		}
		if ( this.UserCanBought() == false ) {
			Debug.LogError("Not enough money to bought this skill or minimum Step is not reach or previous skill not bought.");
			return false;
		}
		// Decrementation de next price
		this._owned = true;
		this._usersSkills.addOwnedSkill( this.gameObject );
		this._currentLevel++;
		return true;
	}

	private				bool		UserCanBought() {
		int		userPoint = GameManager.gm.skillPoints;

		if ( userPoint >= this.GetNextPrice() && this._usersSkills.getUserStep() >= this._minimumStep )
			return true;
		return false;
	}

	public				float		GetNextPrice() {
		float nextLevel = this.GetNextLevel();
		if ( nextLevel < 0 )
			return 0;
		return this._price * this.GetNextLevel();
	}

	public				int			GetNextLevel() {
		if ( this._currentLevel >= this._maxLevel )
			return -1;
		return this._currentLevel + 1;
	}

	// Not good
	public				bool		prevIsOwned() {
		if ( this._prev == null )
			return true;
		return this._prev.isOwned();
	}

	public override		bool		isOwned() {
		return this._owned;
	}
	public override		int			getMaxLevel() {
		return this._maxLevel;
	}
	public override		int			getLevel() {
		return this._currentLevel;
	}
}
