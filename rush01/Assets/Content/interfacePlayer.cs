using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class interfacePlayer : MonoBehaviour {

	public int _health, _exp, _mana, _armo, _con, _maxHealth, _maxMana, _expToLevel, _level, _strength, _agi, _pointComp, _pointSkills;

	public Image healthBar,expBar,manaBar;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetVal ();
		healthBar.fillAmount = _health / _maxHealth * 100;
		expBar.fillAmount = _exp / _expToLevel;
		manaBar.fillAmount = _mana / _maxMana;
	}

	public void GetVal() {
		this._health = (int)GameManager.gm.player.health;
		this._exp = (int)GameManager.gm.player.GetCurrentXp();
		this._mana = (int)GameManager.gm.player.mana;
		this._armo = (int)GameManager.gm.player.armor;
		this._con = (int)GameManager.gm.player.constitution; 
		this._maxHealth = (int)GameManager.gm.player.GetMaxHealth();
		this._maxMana = (int)GameManager.gm.player.GetMaxMana();
		this._expToLevel = (int)GameManager.gm.player.xpMax;
		this._level = (int)GameManager.gm.level;
		this._strength = (int)GameManager.gm.player.force;
		this._agi = (int)GameManager.gm.player.agility;
		this._pointComp = 5;
		this._pointSkills = 5;
	}
}
