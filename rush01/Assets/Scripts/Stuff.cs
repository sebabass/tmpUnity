using UnityEngine;
using System.Collections;

public class Stuff : MonoBehaviour {

	public		ParticleSystem[]	rareParticle;
	protected	string[]			rareName = {"Normal", "Rare", "Ultra rare", "Epique", "Legendaire"};
	protected	int					rareRange;


	protected virtual void Start () {
		rareRange = Random.Range (1, 5);
	}
}
