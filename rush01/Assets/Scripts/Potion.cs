using UnityEngine;
using System.Collections;

public class Potion : Stuff {
	
	public	int	_type;
	private	int	_value;
	
	void Start () {
		if (this.rareRange - 1 >= 0) {
			ParticleSystem go = (ParticleSystem)Instantiate (rareParticle [this.rareRange - 1], transform.position, Quaternion.identity);
			go.gameObject.transform.SetParent (gameObject.transform);
		}
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