using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class skillUi : MonoBehaviour {

	[SerializeField]	protected			GameObject			_userSkill;
	[SerializeField]	protected			GameObject			_btnPrefab;
	[HideInInspector]	protected			UserSkills			_userSkillClass;

	void Start() {
		this._userSkillClass = this._userSkill.GetComponent<UserSkills>();
		foreach(List<Skill> skills in this._userSkillClass.getAllBranches() ) {

			foreach( Skill skill in skills ) {
				Skill obj;

				obj = skill;
				GameObject btn = GameObject.Instantiate( this._btnPrefab );
				btn.transform.SetParent( this.transform );
				btn.GetComponent<Button>().onClick.AddListener(() => Buy( obj ));
				btn.GetComponent<Image>().sprite = skill.getSkillImage();
			}

		}
	}

	void Buy( Skill skill ) {
		this._userSkillClass.bought( skill.gameObject );
	}
}