using UnityEngine;
using System.Collections;


public class CommandLog : MonoBehaviour {

	public static string[] commands = new string[10];
	public static bool startSimulation;
	public static bool addedCommand;
	public static int index;
	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.name)
		{
			case "Ctrl_Play":
				startSimulation = true;
				index += 1;
				addedCommand = true;
				Debug.Log("Touched " + other.gameObject.name);
				break;
			case "Move_Left":
				commands[index] = "moveLeft()";
				index += 1;
				addedCommand = true;
				Debug.Log("Touched " + other.gameObject.name);
				break;
			case "Move_Right":
				commands[index] = "moveRight()";
				index += 1;
				addedCommand = true;
				Debug.Log("Touched " + other.gameObject.name);
				break;
			case "Jump":
				commands[index] = "jump()";
				index += 1;
				addedCommand = true;
				Debug.Log("Touched " + other.gameObject.name);
				break;
			case "Reset":
				commands[index] = "reset()";
				index += 1;
				addedCommand = true;
				Debug.Log("Touched " + other.gameObject.name);
				break;
		}
	}
}
