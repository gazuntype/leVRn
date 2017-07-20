using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevrnScripts;

public class MovePawn : MonoBehaviour
{
	GameObject pawn;

	int index = 0;
	Vector3 pawnDestination;
	float lobHeight = 0.5f;
	float lobTime = .7f;
	// Use this for initialization
	void Start()
	{
		pawn = gameObject;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void RunSimulation()
	{
		if (index < FunctionControl.queuedFunctions.Count)
		{
			TranslateCommand();
			index++;
			iTweenMove();
		}
	}

	void TranslateCommand()
	{
		switch (FunctionControl.queuedFunctions[index].Type)
		{
			case Function.FunctionType.moveForward:
				pawnDestination = pawn.transform.position + new Vector3(0.1f, 0, 0);
				break;
			case Function.FunctionType.moveBack:
				pawnDestination = pawn.transform.position + new Vector3(-0.1f, 0, 0);
				break;
			case Function.FunctionType.moveRight:
				pawnDestination = pawn.transform.position + new Vector3(0, 0, -0.1f);
				break;
			case Function.FunctionType.moveLeft:
				pawnDestination = pawn.transform.position + new Vector3(0, 0, 0.1f);
				break;
		}
	}

	void iTweenMove()
	{
		//iTween.MoveBy(pawn, iTween.Hash("y", lobHeight, "time", lobTime/2, "easeType", iTween.EaseType.easeOutQuad));
		//iTween.MoveBy(pawn, iTween.Hash("y", -lobHeight, "time", lobTime/2, "delay", lobTime/2, "easeType", iTween.EaseType.easeInCubic));     
		iTween.MoveTo(pawn, iTween.Hash("position", pawnDestination, "time", lobTime, "easeType", iTween.EaseType.linear, "onComplete", "RunSimulation"));
	}
}
