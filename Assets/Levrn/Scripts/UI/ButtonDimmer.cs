using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDimmer : MonoBehaviour {
	float distance;
	public GameObject finger;
	Image buttonImage;
	Color originalColor;
	Color finalColor;
	float maxDistance;
	// Use this for initialization
	void Start () {
		maxDistance = 0.14f;
		buttonImage = GetComponent<Image>();
		originalColor = buttonImage.color;
		finalColor = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(finger.transform.position, transform.position);
		if (distance < maxDistance)
		{
			buttonImage.color = GetImageColour();
		}
		Debug.Log(distance);
	}

	Color GetImageColour()
	{
		Color color;
		float interpolant;
		interpolant = distance / maxDistance;
		color = Color.Lerp(finalColor, originalColor, interpolant);
		return color;
	}
}
