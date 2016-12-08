using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MessageBoard : MonoBehaviour {
	public Text[] log;
	Transform dataTracker;
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
		if (dataTracker == null)
		{
			dataTracker = GameObject.Find("DataTracker").GetComponent<Transform>();
		}
		switch ((int)dataTracker.localPosition.y)
		{
			case 1:
				log[index].text = "moveForward()";
				dataTracker.localPosition = new Vector3(0, 0, 0);
				index++;
				break;
			case 2:
				log[index].text = "moveLeft()";
				dataTracker.localPosition = new Vector3(0, 0, 0);
				index++;
				break;
			case 3:
				log[index].text = "moveRight()";
				dataTracker.localPosition = new Vector3(0, 0, 0);
				index++;
				break;
			case 4:
				log[index].text = "jump()";
				dataTracker.localPosition = new Vector3(0, 0, 0);
				index++;
				break;
			case 5:
				log[index].text = "reset()";
				dataTracker.localPosition = new Vector3(0, 0, 0);
				index++;
				break;
		}
	}
}
