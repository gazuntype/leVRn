using UnityEngine;
using System.Collections;

public class MenuButtonClick : MonoBehaviour
{
	[HideInInspector]
	public static GameObject button;
	[HideInInspector]
	public static bool buttonPressed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		buttonPressed = true;
		button = other.gameObject;
	}
}
