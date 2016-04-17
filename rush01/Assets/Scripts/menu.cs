using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {
	
	/*private Vector3    				_posBarLife;
	private RectTransform 			imgProgressLife;
	private RectTransform 			imgProgressLevel;

	private RectTransform 			imgProgressLifeEnemy;
	private bool 					_menu = true;

	/// <summary>
	private int _life = 30;
	private int level = 100;
	/// </summary>

	// Use this for initialization
	void Start () {
		imgProgressLevel = this.transform.GetChild (0).transform.GetChild (0).transform.GetChild (0) as RectTransform;
		imgProgressLife = this.transform.GetChild (0).transform.GetChild (1).transform.GetChild (0) as RectTransform;
		imgProgressLifeEnemy = this.transform.GetChild (0).transform.GetChild (2).transform.GetChild (0) as RectTransform;
		_posBarLife = imgProgressLife.localPosition;
		this.transform.GetChild (0).transform.GetChild(3).GetComponent<TextMesh> ().color = Color.clear;
		pasPropre (true);
	}
	
	// Update is called once per frame
	void Update () {

		//life
		float pv = GameManager.gm.player.stats ["hp"].value;
		float con = GameManager.gm.player.stats ["con"].value;

		if (pv <= 0) {
			this.transform.transform.GetChild (0).GetChild (3).GetComponent<TextMesh> ().color = Color.red;
		}
		imgProgressLife.GetComponent<Image> ().fillAmount = pv / (con * 5);
		this.transform.GetChild (0).transform.GetChild (1).transform.GetChild (2).GetComponent<TextMesh> ().text = ("life : " + pv + " / " + con * 5);

		//level
		float needXp = GameManager.gm.player.stats ["needXp"].value;
		float xp = GameManager.gm.player.stats ["xp"].value;

		imgProgressLevel.GetComponent<Image> ().fillAmount = xp / needXp;
		this.transform.GetChild (0).transform.GetChild (0).transform.GetChild (3).GetComponent<TextMesh> ().text = ("xp : " + xp + " / " + needXp);
		this.transform.GetChild (0).transform.GetChild (0).transform.GetChild (2).GetComponent<TextMesh> ().text = ("Level : " + GameManager.gm.player.stats ["xp"].lvl);
	
		//menu
		if (Input.GetKeyDown (KeyCode.C)) {
			_menu = !_menu;
			pasPropre (_menu);
			setStats ();
		}

		if (GameManager.gm.onEnemy || (GameManager.gm.player.currentTarget && GameManager.gm.player.currentTarget.tag == "ennemy")) {
			imgProgressLifeEnemy.GetComponent<Image> ().fillAmount = GameManager.gm.onEnemy.stats ["hp"].value / (GameManager.gm.onEnemy.stats ["con"].value * 5);
			this.transform.GetChild (0).transform.GetChild (2).transform.GetChild (2).GetComponent<TextMesh> ().text = ("life : " + GameManager.gm.onEnemy.stats ["hp"].value + " / " + GameManager.gm.onEnemy.stats ["con"].value * 5);
			this.transform.GetChild (0).transform.GetChild (2).transform.GetChild (3).GetComponent<TextMesh> ().text = GameManager.gm.onEnemy.name;
		} else {
			imgProgressLifeEnemy.GetComponent<Image> ().fillAmount = 0;
			this.transform.GetChild (0).transform.GetChild (2).transform.GetChild (2).GetComponent<TextMesh> ().text = "no target";
			this.transform.GetChild (0).transform.GetChild (2).transform.GetChild (3).GetComponent<TextMesh> ().text = "no target";
		}
	}

	public void setStats() {
		this.transform.transform.GetChild (1).transform.GetChild(0).GetChild(0).GetComponent<TextMesh> ().text = GameManager.gm.player.stats ["agi"].value.ToString();
		this.transform.transform.GetChild (1).transform.GetChild(1).GetChild(0).GetComponent<TextMesh> ().text = GameManager.gm.player.stats ["str"].value.ToString();
		this.transform.transform.GetChild (1).transform.GetChild(2).GetChild(0).GetComponent<TextMesh> ().text = GameManager.gm.player.stats ["con"].value.ToString();
		this.transform.transform.GetChild (1).transform.GetChild(3).GetChild(0).GetComponent<TextMesh> ().text = GameManager.gm.player.stats ["armor"].value.ToString();

		//level
		this.transform.transform.GetChild (1).transform.GetChild (4).GetChild (0).GetComponent<TextMesh> ().text = ("xp : " + GameManager.gm.player.stats ["hp"].value + " / " + GameManager.gm.player.stats ["con"].value * 5);
		//
		this.transform.transform.GetChild (1).transform.GetChild(5).GetChild(0).GetComponent<TextMesh> ().text = GameManager.gm.player.stats ["money"].value.ToString();
		this.transform.transform.GetChild (1).transform.GetChild(6).GetChild(0).GetComponent<TextMesh> ().text = GameManager.gm.player.stats ["maxDamage"].value.ToString();
		this.transform.transform.GetChild (1).transform.GetChild(7).GetChild(0).GetComponent<TextMesh> ().text = GameManager.gm.player.stats ["minDamage"].value.ToString();
	}

	public void onTarget(bool target) {
		
	}

	public void pasPropre(bool menu) {
	
		int i;
		if (menu == true) {
			i = 0;
			while (i < 8) {
				this.transform.transform.GetChild (1).GetChild (i).GetComponent<TextMesh> ().color = Color.clear;
				this.transform.transform.GetChild (1).GetChild (i).GetChild(0).GetComponent<TextMesh> ().color = Color.clear;
				i++;
			}
			this.transform.transform.GetChild (1).GetComponent<CanvasGroup> ().alpha = 0;
		} else {
			i = 0;
			while (i < 8) {
				this.transform.transform.GetChild (1).GetChild (i).GetComponent<TextMesh> ().color = Color.red;
				this.transform.transform.GetChild (1).GetChild (i).GetChild(0).GetComponent<TextMesh> ().color = Color.red;
				i++;
			}
			this.transform.transform.GetChild (1).GetComponent<CanvasGroup> ().alpha = 1;
		}
	}*/

}
