using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDimmer : MonoBehaviour {
	float distance;
	public GameObject[] fingers;
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
		foreach (GameObject finger in fingers)
		{
			distance = Vector3.Distance(finger.transform.position, transform.position);
			if (distance < maxDistance && CheckFingerHeight())
			{
				buttonImage.color = GetImageColour();
			}
			else
			{
				buttonImage.color = originalColor;
			}
		}
	}

	Color GetImageColour()
	{
		Color color;
		float interpolant;
		interpolant = distance / maxDistance;
		color = Color.Lerp(finalColor, originalColor, interpolant);
		return color;
	}

	bool CheckFingerHeight()
	{
		bool status = false;
		foreach (GameObject finger in fingers)
		{
			if (finger.transform.position.y < transform.position.y + 0.02f && finger.transform.position.y > transform.position.y - 0.02)
			{
				status = true;
			}
			else
			{
				status = false;
			}
		}
		return status;
	}
}
