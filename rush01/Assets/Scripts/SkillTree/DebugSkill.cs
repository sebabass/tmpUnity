using UnityEngine;
using System.Collections;

public class DebugSkill : MonoBehaviour {

	protected		UserSkills			_skillManager;
	protected		int					_index = 0;
	protected		int					_branch = 0;
	protected		int					_owned = 0;

	// Use this for initialization
	void Start () {
		this._skillManager = GetComponent<UserSkills>();
	}
	
	// Update is called once per frame
	void Update () {
		// Buy
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			this._skillManager.boughtNextAvailableSkill( 0 );
			this._branch++;
			Debug.Log( "Buy action" );
		}

		// Ready to use
		if ( Input.GetKeyDown( KeyCode.Return ) ) {
			this._skillManager.addSkillToUsedList( 0, 0 );
			this._skillManager.addSkillToUsedList( 1, 1 );
			this._skillManager.addSkillToUsedList( 2, 2 );
			Debug.Log( "Ready to use action" );
		}

		// Use
		if ( Input.GetKeyDown( KeyCode.Q ) ) {
			this._skillManager.UseAnSkill( this._index % 3 );
			this._index++;
			Debug.Log( "Use action" );
		}

		// LevelUp
		if ( Input.GetKeyDown( KeyCode.UpArrow ) ) {
			this._skillManager.LevelUpAnOwnedSkill( this._owned );
			this._owned++;
			Debug.Log( "LevelUp action" );
		}
	}
}
