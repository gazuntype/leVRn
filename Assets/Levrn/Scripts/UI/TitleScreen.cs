using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	public GameObject title;
	public GameObject menuScreen;

	UIStates state;

	// Use this for initialization
	void Start () {
		state = UIStates.title;
		StartCoroutine(FadeWelcomeScreen());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FadeWelcomeScreen()
	{
		yield return new WaitForSeconds(3);
		title.SetActive(false);
		menuScreen.SetActive(true);
		state = UIStates.menu;
	}

	public void ClickedPlay()
	{
		menuScreen.SetActive(false);
		state = UIStates.level;
	}

	enum UIStates { title, menu, level, help, sublevel }
}
