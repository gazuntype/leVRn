using UnityEngine;
using System.Collections;

public class PawnMotion : MonoBehaviour {
	int commandIndex = 0;
	bool runCommand = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		MovePawn();
	}

	void MovePawn()
	{
		if (MenuButtonClick.buttonPressed)
		{
			if (MenuButtonClick.button.name == "play")
			{
				MenuButtonClick.buttonPressed = false;
				Debug.Log("Na Play");
				StartCoroutine(GetCommands());
			}
		}
	}

	IEnumerator GetCommands()
	{
		string command;
		while (true)
		{
			if (runCommand)
			{
				runCommand = false;
				command = MessageBoard.command[commandIndex];
				StartCoroutine(TranslateCommands(command));
			}
			if (commandIndex == MessageBoard.command.Count - 1)
			{
				yield break;
			}
			yield return null;
		}
	}

	IEnumerator TranslateCommands(string command)
	{
		Vector3 pawnDestination = new Vector3();
		float timeStart = 0f;
		switch (command)
		{
			case "moveForward":
				pawnDestination = transform.position + new Vector3(0.1f, 0, 0);
				break;
			case "moveLeft":
				pawnDestination = transform.position + new Vector3(0, 0, 0.1f);
				break;
			case "moveRight":
				pawnDestination = transform.position + new Vector3(0, 0, -0.1f);
				break;
		}
		while (true)
		{
			timeStart += Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, pawnDestination, timeStart);
			if (transform.position == pawnDestination)
			{
				runCommand = true;
				commandIndex += 1;
				yield break;
			}
			yield return null;
		}
	}
}
