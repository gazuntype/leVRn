using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateUI : MonoBehaviour {

	public GameObject dataTracker;
	public GameObject movingFinger;

	Vector3 initialDashPos;
	Vector3 initialHandPos;

	bool onPinch = false;
	GameObject movingDash;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveDashboard();
	}

	public void SetDataTracker()
	{
		dataTracker.transform.position = new Vector3(5, 0, 0);
		Debug.Log("Pinch was detected");
	}

	public void ResetDataTracker()
	{
		dataTracker.transform.position = new Vector3(0, 0, 0);
		Debug.Log("Pinch was released");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "board" && (int)dataTracker.transform.position.x == 5)
		{
			initialHandPos = movingFinger.transform.position;
			initialDashPos = other.transform.position;
			onPinch = true;
			Debug.Log("Board was pinched and should move");
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "board" && (int)dataTracker.transform.position.x == 5 && !onPinch)
		{
			initialHandPos = movingFinger.transform.position;
			initialDashPos = other.transform.position;
			onPinch = true;
			Debug.Log("Board was pinched and should move");
		}
	}

	void OnTriggerExit(Collider other)
	{
		onPinch = false;
	}

	void MoveDashboard()
	{
		if (onPinch)
		{
			movingDash.transform.position = initialDashPos + (movingFinger.transform.position - initialHandPos);
		}
	}
}
