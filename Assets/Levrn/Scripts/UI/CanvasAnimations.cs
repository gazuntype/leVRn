using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAnimations : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void MoveCanvas(GameObject canvas, Vector3 location)
	{
		iTween.MoveTo(canvas, iTween.Hash("position", location, "time", 1f, "isLocal", true, "easeType", iTween.EaseType.linear));
	}
}
