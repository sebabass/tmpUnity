using UnityEngine;
using System.Collections;

public class UsableObject : Stuff {

	/*
	 * type 0 = "Fait rien";
	 * type 1 = "change caracteristique";
	 */
	public	int	type = 0;
	public	int	value = 0;

	protected override void Start () {
		value *= rareRange;
	}
}
