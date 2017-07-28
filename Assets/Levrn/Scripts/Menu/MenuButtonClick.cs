using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonClick : MonoBehaviour
{
	
	public static bool buttonPressed = false;
	public static GameObject button;

	GameObject rigController;
	FunctionControl functionControl;
	TitleScreen titleScreen;
	SettingsControl settingsControl;
	bool front;
	// Use this for initialization
	void Start () {
		rigController = GameObject.Find("RigController");
		titleScreen = rigController.GetComponent<TitleScreen>();
		functionControl = rigController.GetComponent<FunctionControl>();
		settingsControl = rigController.GetComponent<SettingsControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "button")
		{
			Debug.Log(other.material.name);
		}
		if (other.tag == "button" && other.material.name == "True (Instance)" )
		{
			Debug.Log("Collided with the button");
			front = CheckIfObjectIsInFront(other.transform, transform);
			if (front)
			{
				FeedbackFromButton(other.gameObject);
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "button" && other.material.name == "True (Instance)")
		{
			Debug.Log("Collided with the button");
			front = CheckIfObjectIsInFront(other.transform, transform);
			if (front)
			{
				ButtonClicked(other.name);
				ButtonDimmer.canChange = true;
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

	void FeedbackFromButton(GameObject buttonUsed)
	{
		Image buttonImage = buttonUsed.GetComponent<Image>();
		ButtonDimmer.canChange = false;
		Color darkGreen = new Vector4(0, 100, 0, 1);
		buttonImage.color = Color.blue;

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
			case "Cancel":
				titleScreen.ClickedCancel();
				break;
			case "Run":
				MovePawn movePawn = GameObject.FindGameObjectWithTag("pawn").GetComponent<MovePawn>();
				movePawn.RunSimulation();
				break;
			case "Del":
				functionControl.Del();
				break;
			case "Settings":
				titleScreen.ClickedSettings();
				break;
			case "Restart":
				titleScreen.Restart();
				break;
			case "Blue":
				settingsControl.ChangeTheme(SettingsControl.Theme.blue);
				break;
			case "Red":
				settingsControl.ChangeTheme(SettingsControl.Theme.red);
				break;
			case "Pink":
				settingsControl.ChangeTheme(SettingsControl.Theme.pink);
				break;
			case "White":
				settingsControl.ChangeTheme(SettingsControl.Theme.white);
				break;
			case "Black":
				settingsControl.ChangeTheme(SettingsControl.Theme.black);
				break;
		}
	}

}
