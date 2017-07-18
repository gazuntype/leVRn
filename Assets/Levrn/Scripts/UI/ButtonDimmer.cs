using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDimmer : MonoBehaviour {
	float distance;
	float distance2;
	public GameObject finger;
	public GameObject finger2;

	GameObject closestFinger;
	float closestDistance;
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
		distance2 = Vector3.Distance(finger2.transform.position, transform.position);

		if (distance < distance2)
		{
			closestFinger = finger;
			closestDistance = distance;
		}
		else
		{
			closestFinger = finger2;
			closestDistance = distance2;
		}

		if (closestDistance < maxDistance && CheckFingerHeight(closestFinger))
		{
			buttonImage.color = GetImageColour();
		}

		if (!CheckFingerHeight(closestFinger))
		{
			buttonImage.color = originalColor;
		}
	}

	Color GetImageColour()
	{
		Color color;
		float interpolant;
		interpolant = closestDistance / maxDistance;
		color = Color.Lerp(finalColor, originalColor, interpolant);
		return color;
	}

	bool CheckFingerHeight(GameObject check)
	{
		if (FingerWithin(check))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool FingerWithin(GameObject ifinger)
	{
		return (ifinger.transform.position.y < transform.position.y + 0.02f && ifinger.transform.position.y > transform.position.y - 0.02);
	}
}
