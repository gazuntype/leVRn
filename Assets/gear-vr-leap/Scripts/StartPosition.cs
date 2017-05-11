using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(-21.6f, 2f, -21.9f);
		transform.rotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
