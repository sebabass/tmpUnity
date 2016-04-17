using UnityEngine;
using System.Collections;

public class autoDestruct : MonoBehaviour {

	public		float		expiration = 3f;

	void Start () {
		Destroy( gameObject, this.expiration );
	}
}
