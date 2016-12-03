using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MessageBoard : MonoBehaviour {
	Text message;
	int index;
	// Use this for initialization
	void Start () {
		message = GetComponent<Text>();
		message.text = "Commands:";
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		LogMessage();
	}

	void LogMessage()
	{
		if (CommandLog.addedCommand)
		{
			switch (CommandLog.commands[index])
			{
				case "moveForward()":
					message.text = message.text + "\n moveForward()";
					index += 1;
					CommandLog.addedCommand = false;
					break;
				case "moveLeft()":
					message.text += "\n moveLeft()";
					index += 1;
					CommandLog.addedCommand = false;
					break;
				case "moveRight()":
					Debug.Log("I touched Right");
					message.text += "\n moveRight()";
					Debug.Log(message.text);
					index += 1;
					CommandLog.addedCommand = false;
					break;
				case "jump()":
					message.text += "\n jump()";
					index += 1;
					CommandLog.addedCommand = false;
					break;
				case "reset()":
					message.text += "\n reset()";
					index += 1;
					CommandLog.addedCommand = false;
					break;
			}
		}
	}

}
