using UnityEngine;
using System.Collections;
using Leap.Unity;

public class PalmFlip : PalmDirectionDetector {
	public float flipSpeed;
	Transform dataTracker;
	Vector3 transformData;
	int detectedMovement;//1: leftFlip, 2: pinch, 3: rightFlip
	public int inputDetectedMovement;
	float flipTime;
	bool countFlipTime;

	void Start () {
		dataTracker = GameObject.Find("DataTracker").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	public void Update () {
		if (countFlipTime){
			FlipStart();
		}
	}

	public void FlipRest(){
		flipTime = 0;
		countFlipTime = false;
	}

	public void CountFlip(){
		countFlipTime = true;
	}

	public void FlipStart(){
			flipTime += 1f * Time.deltaTime;
	}

	public void CheckIfFlip(){
		countFlipTime = false;
		if (flipTime < flipSpeed){
			detectedMovement = inputDetectedMovement;
			SetDataTracker();
		}
		flipTime = 0;
	}

	public void CheckHandReturn(){
		detectedMovement = 0;
		SetDataTracker();
	}

	public void SetDataTracker(){
		transformData = new Vector3(detectedMovement, 0, 0);
		dataTracker.position = transformData;
	}
}
