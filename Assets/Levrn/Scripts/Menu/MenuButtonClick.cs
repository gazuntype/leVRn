using UnityEngine;
using System.Collections;

public class MenuButtonClick : MonoBehaviour
{
	public static bool buttonPressed = false;
	public static GameObject button;
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
