using UnityEngine;
using System.Collections;

public class MenuButtonClick : MonoBehaviour
{
	
	public static bool buttonPressed = false;
	public static GameObject button;

	TitleScreen titleScreen;
	bool front;
	// Use this for initialization
	void Start () {
		titleScreen = GameObject.Find("RigController").GetComponent<TitleScreen>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "button")
		{
			front = CheckIfObjectIsInFront(other.transform, transform);
			if (front)
			{
				ButtonClicked(other.name);
			}
		}
	}

	bool CheckIfObjectIsInFront(Transform buttonClicked, Transform finger)
	{
		bool inFront = false;
		Vector3 displacement = finger.position - buttonClicked.position;
		float dotProduct = Vector3.Dot(displacement, buttonClicked.forward);
		if (dotProduct > 0)
		{
			inFront = true;
		}
		else if (dotProduct < 0)
		{
			inFront = false;
		}
		return inFront;
	}

	void ButtonClicked(string buttonName)
	{
		switch (buttonName)
		{
			case "Play":
				titleScreen.ClickedPlay();
				break;
		}
	}

}
