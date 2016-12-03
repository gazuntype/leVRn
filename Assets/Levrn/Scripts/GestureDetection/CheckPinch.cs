using UnityEngine;
using System.Collections;

public class CheckPinch : MonoBehaviour {
	int pinches;
	GameObject[] fingerTrackers;
	Transform dataTracker;
	Vector3 transformData;
	int detectedMovement;
	// Use this for initialization
	void Start () {
		pinches = 0;
		dataTracker = GameObject.Find("DataTracker").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPinch(){
		pinches += 1;
		if (pinches == 2){
			detectedMovement = 2;
			SetDataTracker();
		}
		Debug.Log(pinches);
	}

	public void SubtractPinch(){
		pinches -= 1;
		if (pinches != 2){
			detectedMovement = 0;
			SetDataTracker();
		}
		Debug.Log(pinches);
	}

	public void SetDataTracker(){
		transformData = new Vector3(detectedMovement, 0, 0);
		dataTracker.position = transformData;
	}
}
