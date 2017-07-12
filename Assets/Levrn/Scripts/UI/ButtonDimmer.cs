using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDimmer : MonoBehaviour {
	float distance;
	public GameObject finger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(finger.transform.position, transform.position);
		Debug.Log(distance);
	}
}
