using UnityEngine;
using System.Collections;

public class MenuButtonClick : MonoBehaviour
{
	public Transform dataTracker;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		switch (other.gameObject.name)
		{
			case "moveForward":
				dataTracker.localPosition = new Vector3(dataTracker.localPosition.x, 1, 0);
				break;
			case "moveLeft":
				dataTracker.localPosition = new Vector3(dataTracker.localPosition.x, 2, 0);
				break;
			case "moveRight":
				dataTracker.localPosition = new Vector3(dataTracker.localPosition.x, 3, 0);
				break;
			case "jump":
				dataTracker.localPosition = new Vector3(dataTracker.localPosition.x, 4, 0);
				break;
			case "reset":
				dataTracker.localPosition = new Vector3(dataTracker.localPosition.x, 5, 0);
				break;
		}
	}
}
