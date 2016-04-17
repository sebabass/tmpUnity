using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class interfacePlayer : MonoBehaviour {

	public float _health, _exp, _mana, _armo, _con, _maxHealth, _maxMana, _expToLevel, _level, _strength, _agi, _pointComp, _pointSkills;

	public Image healthBar,expBar,manaBar;
	public Image healthBarEnemy;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetVal ();
		healthBar.fillAmount = _health / _maxHealth;
		expBar.fillAmount = _exp / _expToLevel;
		manaBar.fillAmount = _mana / _maxMana;

		if (GameManager.gm.onEnemy) {
			healthBarEnemy.fillAmount = GameManager.gm.onEnemy.health / GameManager.gm.onEnemy.GetMaxHealth ();
			GameObject.Find("enemyName").GetComponent<Text>().text = GameManager.gm.onEnemy.name;
		} else if (GameManager.gm.player.currentTarget && GameManager.gm.player.currentTarget.tag == "enemy") {
			healthBarEnemy.fillAmount = GameManager.gm.player.currentTarget.GetComponent<Enemy>().health / GameManager.gm.player.currentTarget.GetComponent<Enemy>().GetMaxHealth ();
			GameObject.Find("enemyName").GetComponent<Text>().text = GameManager.gm.player.currentTarget.GetComponent<Enemy>().name;
		} else {
			healthBarEnemy.fillAmount = 0.0f;
			GameObject.Find("enemyName").GetComponent<Text>().text = "";
		}
	}

	public void GetVal() {
		this._health = GameManager.gm.player.health;
		this._exp = GameManager.gm.player.GetCurrentXp();
		this._mana = GameManager.gm.player.mana;
		this._armo = GameManager.gm.player.armor;
		this._con = GameManager.gm.player.constitution; 
		this._maxHealth = GameManager.gm.player.GetMaxHealth();
		this._maxMana = GameManager.gm.player.GetMaxMana();
		this._expToLevel = GameManager.gm.player.xpMax;
		this._level = GameManager.gm.level;
		this._strength = GameManager.gm.player.force;
		this._agi = GameManager.gm.player.agility;
		this._pointComp = GameManager.gm.competencePoints;
		this._pointSkills = GameManager.gm.skillPoints;
	}
}
