using UnityEngine;
using System.Collections;

public class TrackedData : MonoBehaviour {

	Transform dataTracker;
	Vector3 trackedTransform;
	GameObject[] fingerTrackers;
	int trackedData;
	Rigidbody sphereRB;
	public GameObject platform;
	// Use this for initialization
	void Start () {
		dataTracker = GameObject.Find("DataTracker").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		trackedTransform = dataTracker.position;
		trackedData = (int)trackedTransform.x;
		if (trackedData == 2){
			fingerTrackers = GameObject.FindGameObjectsWithTag("FingerTracker");
			float distance;
			distance = (fingerTrackers[1].transform.position - fingerTrackers[0].transform.position).magnitude;
			distance = distance * 5;
			platform.transform.localScale = new Vector3(distance + 1, distance + 1, distance + 1);
		}
	}
}
