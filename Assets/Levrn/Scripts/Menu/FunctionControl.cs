using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevrnScripts;

public class FunctionControl : MonoBehaviour {
	public GameObject del;
	public GameObject run;

	[HideInInspector]
	public static List<Function> queuedFunctions = new List<Function>();

	public Text[] entree;

	public void ClickedMoveForward()
	{
		if (queuedFunctions.Count == 0)
		{
			del.SetActive(true);
			run.SetActive(true);
		}
		Function function = new Function("moveForward()", Function.FunctionType.moveForward);
		entree[queuedFunctions.Count].text = function.FunctionName;
		queuedFunctions.Add(function);
	}

	public void ClickedMoveLeft()
	{
		if (queuedFunctions.Count == 0)
		{
			del.SetActive(true);
			run.SetActive(true);
		}
		Function function = new Function("moveLeft()", Function.FunctionType.moveLeft);
		entree[queuedFunctions.Count].text = function.FunctionName;
		queuedFunctions.Add(function);
	}

	public void ClickedMoveRight()
	{
		if (queuedFunctions.Count == 0)
		{
			del.SetActive(true);
			run.SetActive(true);
		}
		Function function = new Function("moveRight()", Function.FunctionType.moveRight);
		entree[queuedFunctions.Count].text = function.FunctionName;
		queuedFunctions.Add(function);
	}

	public void ClickedMoveBack()
	{
		if (queuedFunctions.Count == 0)
		{
			del.SetActive(true);
			run.SetActive(true);
		}
		Function function = new Function("moveBack()", Function.FunctionType.moveBack);
		entree[queuedFunctions.Count].text = function.FunctionName;
		queuedFunctions.Add(function);
	}

	public void Del()
	{
		entree[queuedFunctions.Count - 1].text = "";
		queuedFunctions.RemoveAt(queuedFunctions.Count - 1);
		if (queuedFunctions.Count == 0)
		{
			del.SetActive(false);
			run.SetActive(false);
		}
	}
}
