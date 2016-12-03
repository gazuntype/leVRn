using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dashboard : MonoBehaviour {
	public GameObject[] commands;
	public GameObject texto;
	public Transform canvas;
	Text[] commandText = new Text[5];
	int index;

	// Use this for initialization
	void Start () {
		index = 0;
		for (int i = 0; i < 5; i++)
		{
			commandText[i] = commands[i].GetComponentInChildren<Text>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (CommandLog.addedCommand)
		{
			Instantiate(texto);
			texto.transform.SetParent(canvas);
			index += 1;
			CommandLog.addedCommand = false;
		}
	}
}
