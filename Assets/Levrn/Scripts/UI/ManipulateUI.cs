using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateUI : MonoBehaviour {

	public GameObject dataTracker;
	public GameObject movingFinger;
	//public GameObject otherFinger;
	//public float scaleFactor;

	[HideInInspector]
	public static List<Vector3> zoomInitialPos = new List<Vector3>();

	[HideInInspector]
	public static bool onZoom = false;

	[HideInInspector]
	public static bool onPinch = false;

	Vector3 initialDashScale;
	float initialHandDistance;
	Vector3 initialDashPos;
	Vector3 initialHandPos;

	GameObject movingDash;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveDashboard();
		//ScaleDashboard();
	}

	public void SetDataTracker()
	{
		if ((int)dataTracker.transform.position.x != 5)
		{
			dataTracker.transform.position = new Vector3(5, 0, 0);
			Debug.Log("Pinch was detected");
		}
		/*else if ((int)dataTracker.transform.position.x == 5)
		{
			dataTracker.transform.position = new Vector3(6, 0, 0);
			Debug.Log("Double pinch was detected");
		}*/
	}

	public void ResetDataTracker()
	{
		dataTracker.transform.position = new Vector3(0, 0, 0);
		zoomInitialPos.Clear();
		Debug.Log("Pinch was released");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "board")
		{
			Debug.Log((int)dataTracker.transform.position.x);
			if ((int)dataTracker.transform.position.x == 5)
			{
				initialHandPos = movingFinger.transform.position;
				initialDashPos = other.transform.position;
				movingDash = other.gameObject;
				onPinch = true;
				Debug.Log("Board was pinched and should move");
			}
			/*else if ((int)dataTracker.transform.position.x == 6)
			{
				zoomInitialPos.Add(movingFinger.transform.position);
				initialDashScale = other.transform.localScale;
				initialHandDistance = Vector3.Distance(movingFinger.transform.position, otherFinger.transform.position);
				Debug.Log("Board was double pinched and should zoom");
				onZoom = true;

			}*/
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "board" && (int)dataTracker.transform.position.x == 5 && !onPinch)
		{
			initialHandPos = movingFinger.transform.position;
			initialDashPos = other.transform.position;
			movingDash = other.gameObject;
			onPinch = true;
			Debug.Log("Board was pinched and should move");
		}

		/*if (other.tag == "board" && (int)dataTracker.transform.position.x == 6 && !onZoom)
		{
			zoomInitialPos.Add(movingFinger.transform.position);
			initialDashScale = other.transform.localScale;
			initialHandDistance = Vector3.Distance(movingFinger.transform.position, otherFinger.transform.position);
			Debug.Log("Board was double pinched and should zoom");
			onZoom = true;
		}*/
	}

	void OnTriggerExit(Collider other)
	{
		onZoom = false;
		movingDash = null;
		onPinch = false;
		Debug.Log("Left the board");
	}

	void MoveDashboard()
	{
		if (onPinch && (int)dataTracker.transform.position.x == 5)
		{
			movingDash.transform.position = initialDashPos + (movingFinger.transform.position - initialHandPos);
		}
	}

	/*void ScaleDashboard()
	{
		if (onZoom && (int)dataTracker.transform.position.x == 6)
		{
			float handDistance = Vector3.Distance(movingFinger.transform.position, otherFinger.transform.position);
			movingDash.transform.localScale = initialDashScale * scaleFactor * (handDistance - initialHandDistance);
		}
	}*/
}
