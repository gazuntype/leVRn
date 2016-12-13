using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class MessageBoard : MonoBehaviour {
	public Text[] log;
	[HideInInspector]
	public static List<string> command = new List<string>();
	int index;
	void Start()
	{
		index = 0;
	}

	void Update()
	{
		AddLog();
	}

	void AddLog()
	{
		if (MenuButtonClick.buttonPressed)
		{
			if (MenuButtonClick.button.tag == "functionButton")
			{
				log[index].text = MenuButtonClick.button.name + "()";
				command.Add(MenuButtonClick.button.name);
				MenuButtonClick.buttonPressed = false;
				index++;
			}
		}
	}
}
