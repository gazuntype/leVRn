using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MessageBoard : MonoBehaviour {
	public GameObject[] log;
	public Transform dashboard;
	int position;
	void Start()
	{
		position = 3;
	}

	void Update()
	{
		AddLog();
	}

	void AddLog()
	{
		if (MenuButtonClick.buttonPressed)
		{
			GameObject buttonClicked;
			switch (MenuButtonClick.button.name)
			{
				case "moveForward":
					buttonClicked = (GameObject)Instantiate(log[0], dashboard.position, Quaternion.identity);
					buttonClicked.transform.SetParent(dashboard);
					buttonClicked.transform.position = new Vector3(0, 0.15f * position, 0);
					break;
				case "moveLeft":
					buttonClicked = (GameObject)Instantiate(log[1], dashboard.position, Quaternion.identity);
					buttonClicked.transform.SetParent(dashboard);
					buttonClicked.transform.position = new Vector3(0, 0.15f * position, 0);
					break;
				case "moveRight":
					buttonClicked = (GameObject)Instantiate(log[2], dashboard.position, Quaternion.identity);
					buttonClicked.transform.SetParent(dashboard);
					buttonClicked.transform.position = new Vector3(0, 0.15f * position, 0);
					break;
				case "jump":
					buttonClicked = (GameObject)Instantiate(log[3], dashboard.position, Quaternion.identity);
					buttonClicked.transform.SetParent(dashboard);
					buttonClicked.transform.position = new Vector3(0, 0.15f * position, 0);
					break;
				case "reset":
					buttonClicked = (GameObject)Instantiate(log[4], dashboard.position, Quaternion.identity);
					buttonClicked.transform.SetParent(dashboard);
					buttonClicked.transform.position = new Vector3(0, 0.15f * position, 0);
					break;
			}
			position -= 1;
			MenuButtonClick.buttonPressed = false;
		}
	}
}
