using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class skillUsedUI : MonoBehaviour {
	
	[SerializeField]	protected			GameObject			_userSkill;
	[SerializeField]	protected			GameObject			_btnPrefab;
	[HideInInspector]	protected			UserSkills			_userSkillClass;
	[HideInInspector]	protected			int					_ownedCount = -1;
	void Start() {
		this._userSkillClass = this._userSkill.GetComponent<UserSkills>();
	}
	
	void Update() {

		this.listenKeys();
		int inst = 0;
		List<Skill> skills = this._userSkillClass.getSkillsUsed();
		for( int i = 0; i < skills.Count; i++ ) {
			if ( skills[i] != null )
				inst++;
		}
		if ( inst == this._ownedCount )
			return ;
		
		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		
		for( int i = 0; i < skills.Count; i++ ) {
			int e;
			
			e = i;
			GameObject btn = GameObject.Instantiate( this._btnPrefab );
			btn.transform.SetParent( this.transform );
			btn.GetComponent<Button>().onClick.AddListener(() => removeUsed( e ));

			btn.GetComponentInChildren<Text>().text = ( skills[i] != null )?(e+1).ToString():"-";
			if ( skills[i] != null )
				btn.GetComponent<Image>().sprite = skills[i].getSkillImage();
		}
		this._ownedCount = skills.Count;
	}

	void listenKeys() {
		if ( Input.GetKeyUp( KeyCode.Keypad1 ) )
			this._userSkillClass.UseAnSkill( 0 );
		else if ( Input.GetKeyUp( KeyCode.Keypad2 ) )
			this._userSkillClass.UseAnSkill( 1 );
		else if ( Input.GetKeyUp( KeyCode.Keypad3 ) )
			this._userSkillClass.UseAnSkill( 2 );
		else if ( Input.GetKeyUp( KeyCode.Keypad4 ) )
			this._userSkillClass.UseAnSkill( 3 );
	}

	void removeUsed( int e ) {
		this._userSkillClass.removeUsedSkill( e );
	}
}
