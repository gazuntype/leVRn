using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleScreen : MonoBehaviour {

	public GameObject title;
	public GameObject menuScreen;
	public GameObject levelScreen;
	public GameObject functionScreen;
	public GameObject loseScreen;
	public GameObject menuCanvas;
	public GameObject methodCanvas;
	public GameObject dashboardCanvas;
	public GameObject gameController;
	public GameObject settingCanvas;

	public Text instruction;

	[Header("Instructions")]
	[TextArea]
	public string[] functionInstruction;

	GameObject rigController;
	FunctionControl functionControl;

	int index = 1;
	UIStates state;
	float fadeOutTime;


	// Use this for initialization
	void Start () {
		rigController = GameObject.Find("RigController");
		functionControl = GetComponent<FunctionControl>();
		fadeOutTime = 3;
		state = UIStates.title;
		StartCoroutine(FadeWelcomeScreen());
	}
	
	// Update is called once per frame

	IEnumerator FadeWelcomeScreen()
	{
		yield return new WaitForSeconds(fadeOutTime);
		title.SetActive(false);
		menuScreen.SetActive(true);
		state = UIStates.menu;
	}

	public void ClickedPlay()
	{
		menuScreen.SetActive(false);
		levelScreen.SetActive(true);
		state = UIStates.level;
	}

	public void ClickedSettings()
	{
		settingCanvas.SetActive(true);
		menuCanvas.SetActive(false);
	}

	public void ClickedCancel()
	{
		settingCanvas.SetActive(false);
		menuCanvas.SetActive(true);
	}

	public void ClickedFunctions()
	{
		levelScreen.SetActive(false);
		functionScreen.SetActive(true);
		methodCanvas.SetActive(true);
		dashboardCanvas.SetActive(true);
		gameController.SetActive(true);
		CanvasAnimations.MoveCanvas(menuCanvas, new Vector3(-0.28f, 0, 0.2f));
		CanvasAnimations.MoveCanvas(dashboardCanvas, new Vector3(0, 0, 0.35f));
		CanvasAnimations.MoveCanvas(methodCanvas, new Vector3(0.24f, 0, 0.25f));
		state = UIStates.function;
	}

	public void FailedChallenge()
	{
		functionScreen.SetActive(false);
		loseScreen.SetActive(true);
	}

	public void NextInstruction()
	{
		if (index == functionInstruction.Length - 1)
		{
			index = 0;
		}
		else
		{
			index++;
		}
		instruction.text = functionInstruction[index];
	}

	public void PreviousInstruction()
	{
		if (index == 0)
		{
			index = functionInstruction.Length - 1;
		}
		else
		{
			index--;
		}
		instruction.text = functionInstruction[index];
	}

	public void Restart()
	{
		loseScreen.SetActive(false);
		functionScreen.SetActive(true);
		GameObject player = GameObject.FindGameObjectWithTag("pawn");
		MovePawn movePawn;
		movePawn = player.GetComponent<MovePawn>();
		movePawn.ReturnToStart();
		functionControl.DeleteAll();
	}


	enum UIStates { title, menu, level, function, help, sublevel }
}
