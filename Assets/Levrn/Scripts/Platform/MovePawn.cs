using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevrnScripts;

public class MovePawn : MonoBehaviour {

	int index = 0;
	Vector3 pawnDestination;
	float lobHeight = 0.5f;
	float lobTime = .7f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RunSimulation()
	{
		if (index < FunctionControl.queuedFunctions.Count)
		{
			TranslateCommand();
			iTweenMove();
			index++;
		}
	}

	void TranslateCommand()
	{
		switch (FunctionControl.queuedFunctions[index].Type)
			{
				case Function.FunctionType.moveForward:
					pawnDestination = transform.position + new Vector3(0.1f, 0, 0);
					break;
				case Function.FunctionType.moveBack:
					pawnDestination = transform.position + new Vector3(-0.1f, 0, 0);
					break;
				case Function.FunctionType.moveRight:
					pawnDestination = transform.position + new Vector3(0, 0, -0.1f);
					break;
				case Function.FunctionType.moveLeft:
					pawnDestination = transform.position + new Vector3(0, 0, 0.1f);
					break;
			}
	}

	void iTweenMove()
	{
		iTween.MoveBy(gameObject, iTween.Hash("y", lobHeight, "time", lobTime/2, "easeType", iTween.EaseType.easeOutQuad));
		iTween.MoveBy(gameObject, iTween.Hash("y", -lobHeight, "time", lobTime/2, "delay", lobTime/2, "easeType", iTween.EaseType.easeInCubic));     
		iTween.MoveTo(gameObject, iTween.Hash("position", pawnDestination, "time", lobTime, "easeType", iTween.EaseType.linear, "onComplete", "TranslateCommand"));
	}
}
