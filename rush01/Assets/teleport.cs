using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour {

	public GameObject	b;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			col.transform.position = b.transform.position;
		}
	}
}
