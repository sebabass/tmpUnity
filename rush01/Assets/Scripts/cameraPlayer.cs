using UnityEngine;
using System.Collections;

public class cameraPlayer : MonoBehaviour {

	public GameObject player;
	public float distance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, distance, player.transform.position.z - distance + 10);
	}
}
