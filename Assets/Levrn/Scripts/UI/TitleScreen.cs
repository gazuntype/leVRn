using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	public GameObject title;
	public GameObject menuScreen;
	public GameObject levelScreen;
	public GameObject functionScreen;
	public GameObject methodCanvas;
	public GameObject dashboardCanvas;

	UIStates state;
	float fadeOutTime;

	// Use this for initialization
	void Start () {
		fadeOutTime = 3;
		state = UIStates.title;
		StartCoroutine(FadeWelcomeScreen());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FadeWelcomeScreen()
	{
		yield return new WaitForSeconds(fadeOutTime);
		title.SetActive(false);
		menuScreen.SetActive(true);
		state = UIStates.menu;
	}

	public void ClickedPlay()
	{
		menuScreen.SetActive(false);
		levelScreen.SetActive(true);
		state = UIStates.level;
	}

	public void ClickedFunctions()
	{
		levelScreen.SetActive(false);
		functionScreen.SetActive(true);
		methodCanvas.SetActive(true);
		dashboardCanvas.SetActive(true);
		state = UIStates.function;

	}


	enum UIStates { title, menu, level, function, help, sublevel }
}
