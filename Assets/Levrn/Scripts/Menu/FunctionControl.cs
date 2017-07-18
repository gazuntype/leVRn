using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevrnScripts;

public class FunctionControl : MonoBehaviour {

	[HideInInspector]
	public static List<Function> queuedFunctions = new List<Function>();

	public Text[] entree;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickedMoveForward()
	{
		Function function = new Function("moveForward", Function.FunctionType.moveForward);
		entree[queuedFunctions.Count].text = function.functionName;
		queuedFunctions.Add(function);
	}

	public void ClickedMoveLeft()
	{
		Function function = new Function("moveLeft", Function.FunctionType.moveLeft);
		entree[queuedFunctions.Count].text = function.functionName;
		queuedFunctions.Add(function);
	}

	public void ClickedMoveRight()
	{
		Function function = new Function("moveRight", Function.FunctionType.moveRight);
		entree[queuedFunctions.Count].text = function.functionName;
		queuedFunctions.Add(function);
	}

	public void ClickedMoveBack()
	{
		Function function = new Function("moveBack", Function.FunctionType.moveBack);
		entree[queuedFunctions.Count].text = function.functionName;
		queuedFunctions.Add(function);
	}
}
