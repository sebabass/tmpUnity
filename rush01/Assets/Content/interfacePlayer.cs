using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class interfacePlayer : MonoBehaviour {

	public int _health, _exp, _mana, _armo, _con, _maxHealth, _maxMana, _expToLevel, _level, _strength, _agi, _pointComp, _pointSkills;

	public Image healthBar,expBar,manaBar;
	// Use this for initialization
	void Start () {
		setVal ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = _health / _maxHealth * 100;
		expBar.fillAmount = _exp / _expToLevel;
		manaBar.fillAmount = _mana / _maxMana;
	}

	public void setVal() {
		this._health = 50;
		this._exp = 10;
		this._mana = 10;
		this._armo = 10;
		this._con = 50; 
		this._maxHealth = 50; 
		this._maxMana = 50;
		this._expToLevel = 1000;
		this._level = 2;
		this._strength = 2;
		this._agi = 10;
		this._pointComp = 5;
		this._pointSkills = 5;
	}
}
