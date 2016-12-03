using UnityEngine;
using System.Collections;

public class PawnMotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (CommandLog.startSimulation){
			Debug.Log("I got here");
			transform.Translate(new Vector3(0.2f, 0, 0));
			transform.Translate(new Vector3(0, 0, 0.4f));
			transform.Translate(new Vector3(0.4f, 0, 0));
			CommandLog.startSimulation = false;
		}
	}
}
