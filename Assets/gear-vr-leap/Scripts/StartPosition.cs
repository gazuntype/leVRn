using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(-2.4f, 2f, 38.4f);
		transform.rotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
