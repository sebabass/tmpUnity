using UnityEngine;
using System.Collections;

public class Potion : Stuff {
	
	public	int	_type;
	private	int	_value;
	
	void Start () {
		_value = (int)((GameManager.gm.player.GetMaxHealth() * rareRange) * 0.1f);
	}
	
	void OnTriggerEnter(Collider coll) {
		if (coll.transform.CompareTag("Player")) {
			if (this._type == 0)
				GameManager.gm.player.ModifyHealth (this._value);
			else
				GameManager.gm.player.ModifyMana(this._value);
			GameObject.Destroy(this.gameObject);
		}
	}
}