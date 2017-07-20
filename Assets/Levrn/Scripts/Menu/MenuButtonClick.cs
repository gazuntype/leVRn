using UnityEngine;
using System.Collections;

public class MenuButtonClick : MonoBehaviour
{
	
	public static bool buttonPressed = false;
	public static GameObject button;

	GameObject rigController;
	FunctionControl functionControl;
	TitleScreen titleScreen;
	bool front;
	// Use this for initialization
	void Start () {
		rigController = GameObject.Find("RigController");
		titleScreen = rigController.GetComponent<TitleScreen>();
		functionControl = rigController.GetComponent<FunctionControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "button")
		{
			Debug.Log("Collided with the button");
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
		if (dotProduct < 0)
		{
			inFront = true;
		}
		else if (dotProduct > 0)
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
			case "Level1":
				titleScreen.ClickedFunctions();
				break;
			case "MoveForward":
				functionControl.ClickedMoveForward();
				break;
			case "MoveLeft":
				functionControl.ClickedMoveLeft();
				break;
			case "MoveRight":
				functionControl.ClickedMoveRight();
				break;
			case "MoveBack":
				functionControl.ClickedMoveBack();
				break;
			case "Next":
				titleScreen.NextInstruction();
				break;
			case "Back":
				titleScreen.PreviousInstruction();
				break;
			case "Run":
				MovePawn movePawn = GameObject.FindGameObjectWithTag("pawn").GetComponent<MovePawn>();
				movePawn.RunSimulation();
				break;
			case "Del":
				functionControl.Del();
				break;
		}
	}

}
