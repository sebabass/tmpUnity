using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class skillOwnedUi : MonoBehaviour {
	
	[SerializeField]	protected			GameObject			_userSkill;
	[SerializeField]	protected			GameObject			_btnPrefab;
	[HideInInspector]	protected			UserSkills			_userSkillClass;
	[HideInInspector]	protected			int					_ownedCount = 0;
	void Start() {
		this._userSkillClass = this._userSkill.GetComponent<UserSkills>();
	}

	void Update() {
		List<Skill> skills = this._userSkillClass.getSkillsOwned();
		if ( skills.Count == this._ownedCount )
			return ;

		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		for( int i = 0; i < skills.Count; i++ ) {
			int e;

			e = i;
			GameObject btn = GameObject.Instantiate( this._btnPrefab );
			btn.transform.SetParent( this.transform );
			btn.GetComponent<Button>().onClick.AddListener(() => AddUsed( e ));
		}
		this._ownedCount = skills.Count;
	}
	
	void AddUsed( int e ) {
		this._userSkillClass.addSkillToUsedList( e, this._userSkillClass.GetFirstClearKey() );
	}
}
