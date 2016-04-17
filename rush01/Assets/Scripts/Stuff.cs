using UnityEngine;
using System.Collections;

public class Stuff : MonoBehaviour {

	public		ParticleSystem[]	rareParticle;
	protected	int					rareRange;
	protected	string[]			rareName = {"Normal", "Rare", "Ultra rare", "Epique", "Legendaire"};

	void Start () {
		rareRange = Random.Range (1, 5);
	}
}
