using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserSkills : MonoBehaviour {

	const									int					maxUsedSkill = 4;
	const									int					levelPerStep = 5;

	[SerializeField]	protected			List<Skill>			_skillsOwned = new List<Skill>();
	[SerializeField]	protected			List<Skill>			_skillsUsed  = new List<Skill>();
	[SerializeField]	protected			List<GameObject>	_branchStart = new List<GameObject>();

	public List<Skill> getSkillsOwned() {
		return this._skillsOwned;
	}

	public List<Skill> getSkillsUsed() {
		return this._skillsUsed;
	}

	// Use to buy next available skill
	public bool 					boughtNextAvailableSkill( int branchIndex ) {
		Skill NextAvailable;
		Skill LastAvailable;

		if ( this._branchStart.Count <= branchIndex ) {
			Debug.LogError( "Branch index (#" + branchIndex + ") not found" );
			return false;
		}
		LastAvailable = this.getLastSkillOwnedByBranchIndex( branchIndex );
		if ( LastAvailable != null ) {
			NextAvailable = LastAvailable.GetNextSkill();
		}else {
			NextAvailable = this.getBranch( branchIndex )[0];
		}
		if ( NextAvailable == null ) {
			Debug.LogError("No skill in this branch");
			return false;
		}
		return this.bought( NextAvailable.gameObject );
	}

	// Level Up An owned Skill
	public bool						LevelUpAnOwnedSkill( int index ) {
		Skill ownedSkill = this.getOwnedSkill( index );
		if ( ownedSkill == null ) {
			Debug.LogError( "Owned skill (#" + index + ") not found" );
			return false;
		}
		return this.bought( ownedSkill.gameObject );
	}

	// Get all branch list
	public	List<List<Skill>>			getAllBranches() {
		List<List<Skill>> allBranches = new List<List<Skill>>();
		foreach( GameObject beginning in this._branchStart ) {
			Skill beginningSkill = (Skill)beginning.GetComponent<Skill>();
			if ( beginningSkill == null )
				continue;
			allBranches.Add( beginningSkill.getBranch() );
		}
		return allBranches;
	}

	// Get branch list
	public List<Skill>		getBranch( int index ) {
		if ( this._branchStart[ index ] == null )
			return null;
		Skill beginningSkill = (Skill)this._branchStart[ index ].GetComponent<Skill>();
		if ( beginningSkill == null )
			return null;
		return beginningSkill.GetComponent<Skill>().getBranch();
	}

	// Add an owned skill to used list
	public bool						addSkillToUsedList( int ownIndex, int index ) {
		if ( index > UserSkills.maxUsedSkill - 1 )
			return false;
		Skill skillInstance = this.getOwnedSkill( ownIndex );
		if ( skillInstance == null )
			return false;
		this.removeUsedSkill( index );
		this._skillsUsed.Insert( index, skillInstance );
		return true;
	}

	// Return an OwnedSkill
	public 	Skill 					getOwnedSkill( int index ) {
		if ( this._skillsOwned[ index ] == null )
			return null;
		return this._skillsOwned[index];
	}

	public void							UseAnSkill( int index ) {
		if ( index > UserSkills.maxUsedSkill - 1 )
			return ;
		if ( this._skillsUsed[ index ] == null ) {
			return ;
		}
		this._skillsUsed[ index ].use();
	}

	public int							GetFirstClearKey() {
		for ( int i = 0; i < UserSkills.maxUsedSkill; i++ ) {
			if ( this._skillsUsed[i] == null )
				return i;
		}
		return 0;
	}


//	public GameObject getSkillGameObject( this.




	protected	Skill				getLastSkillOwnedByBranchIndex( int branchIndex ) {
		Skill			tree = null;
		int				treePos = 0;

		foreach( Skill skillInst in this._skillsOwned ) {
			if ( skillInst.getTreeIndex() == branchIndex && skillInst.getTreePos() >= treePos ) {
				tree = skillInst;
				treePos = skillInst.getTreePos();
			}
		}
		return (tree == null)?null:tree;
	}
	
	public bool						bought( GameObject entity ) {
		GameObject skill = this.getGameObjectByPrefab( entity );
		Skill skillClass = skill.GetComponent<Skill>();
		
		skillClass.UpdateUserSkills();
		if ( skillClass.Unlock() == false && this.SkillAlreadyOwn( skillClass.getName() ) == false ) {
			GameObject.Destroy( skill );
			return false;
		}
		return true;
	}





	// Use to remove an used skill
	public bool 						removeUsedSkill( int index ) {
		if ( index > UserSkills.maxUsedSkill - 1 )
			return false;
		this._skillsUsed.RemoveAt( index );
		return true;
	}

	/**
	 * PUBLIC Methods
	 */
	public 	void				Start() {
		this.initSkillsUsedList();
	}



	public 	bool			addOwnedSkill( GameObject skill ) {
		Skill skillInstance = skill.GetComponent<Skill>();
		if ( skillInstance == null )
			return false;
		if ( this._skillsOwned.Exists( x => x.GetInstanceID() == skillInstance.GetInstanceID() ) == false )
			this._skillsOwned.Add( skillInstance );
		return true;
	}
	
	public int			getUserStep() {
		//		int		userLevel = GameManager.gm.level; // Get User Level ? Right ?
		int		userLevel = 30;
		return Mathf.FloorToInt( userLevel / UserSkills.levelPerStep );
	}


	/**
	 * PRIVATE Methods
	 */
	private void 				initSkillsUsedList() {
		for ( int i = 0; i < UserSkills.maxUsedSkill; i++ ) {
			this._skillsUsed.Add( null );
		}
	}


	private bool		SkillAlreadyOwn( string name ) {
		if ( this._skillsOwned.Exists( x => x.getName() == name ) )
			return true;
		return false;
	}

	private GameObject	getGameObjectByPrefab( GameObject entity ) {
		GameObject skill = GameObject.Instantiate( entity );
		Skill skillClass = skill.GetComponent<Skill>();
		string tmpName = skillClass.getName();

		if ( this.SkillAlreadyOwn( tmpName ) ) {
			Debug.Log( "FOUND" );
			return this._skillsOwned.Find(  x => x.getName() == tmpName ).gameObject;
		}
		return skill;
	}
}
