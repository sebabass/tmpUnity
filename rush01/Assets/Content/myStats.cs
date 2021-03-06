﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class myStats : MonoBehaviour {
	private int alpha = 1;

	private interfacePlayer playerInterface;
	// Use this for initialization
	void Start () {
		playerInterface = GameObject.Find ("CanvasMenu").GetComponent<interfacePlayer> ();
	}

	// Update is called once per frame
	void Update () {
		setMenu ();
	}

	public void setMenu() {
		GameObject.Find ("levelTextPlayer").GetComponent<Text> ().text = "Level : " + playerInterface._level;
		GameObject.Find ("xpTextPlayer").GetComponent<Text> ().text = playerInterface._exp + "/" + playerInterface._expToLevel;
		GameObject.Find ("manaTextPlayer").GetComponent<Text> ().text = playerInterface._mana + "/" + playerInterface._maxMana;
		GameObject.Find ("lifeTextPlayer").GetComponent<Text> ().text = playerInterface._health + "/" + playerInterface._maxHealth;
		GameObject.Find ("constTextPlayer").GetComponent<Text> ().text = playerInterface._con.ToString();
		GameObject.Find ("armorTextPlayer").GetComponent<Text> ().text = playerInterface._armo.ToString();
		GameObject.Find ("strengthTextPlayer").GetComponent<Text> ().text = playerInterface._strength.ToString();
		GameObject.Find ("agilityTextPlayer").GetComponent<Text> ().text = playerInterface._agi.ToString();
		GameObject.Find ("competencePointPlayer").GetComponent<Text> ().text = playerInterface._pointComp.ToString();
//		GameObject.Find ("pointOfSkillPlayer").GetComponent<Text> ().text = playerInterface._pointSkills.ToString();
	}

	public void setStats(int i) {
		if ((playerInterface._pointComp > 0 && i <= 3) || (playerInterface._pointComp < 5 && i >= 4) ) {
			switch (i) {
				case 0 :
					GameManager.gm.player.agility++;
					GameManager.gm.competencePoints--;
					break;
				case 1 :
					GameManager.gm.player.force++;
					GameManager.gm.competencePoints--;
					break;
				case 2 :
					GameManager.gm.player.armor++;
					GameManager.gm.competencePoints--;
					break;
				case 3 :
					GameManager.gm.player.constitution++;
					GameManager.gm.competencePoints--;
					break;
			}
		}
	}

	public void addXP(int xp) {
			playerInterface._exp += xp;
	}

	public void hitMe(int hit) {
		if (playerInterface._health - hit <= 0)
			playerInterface._health = 0;
		else
			playerInterface._health -= hit;
	}

	public void statsAffiche() {
		if (alpha == 1) {
			alpha = 0;
			GameObject.Find ("statsContainers").GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
		else {
			alpha++;
			GameObject.Find ("statsContainers").GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
		GameObject.Find ("statsContainers").GetComponent<CanvasGroup> ().alpha = alpha;
	}
}
