using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevrnScripts;

public class MovePawn : MonoBehaviour
{
	GameObject pawn;

	float initialY;
	int index = 0;
	Vector3 pawnDestination;
	float lobHeight = 0.1f;
	float lobTime = .8f;
	// Use this for initialization
	void Start()
	{
		initialY = transform.position.y;
		pawn = transform.GetChild(0).gameObject;
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
		//transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
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
		iTween.MoveBy(pawn, iTween.Hash("z", lobHeight, "time", lobTime/2, "easeType", iTween.EaseType.easeOutQuad));
		iTween.MoveBy(pawn, iTween.Hash("z", -lobHeight, "time", 0.35f, "delay", lobTime/2, "easeType", iTween.EaseType.easeInCubic));     
		iTween.MoveTo(gameObject, iTween.Hash("position", pawnDestination, "time", lobTime, "easeType", iTween.EaseType.linear, "onComplete", "RunSimulation"));
	}
}
