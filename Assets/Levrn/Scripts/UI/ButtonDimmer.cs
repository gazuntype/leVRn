using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDimmer : MonoBehaviour {
	public static bool canChange = true;

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
	bool fingerClose;
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

		if (closestDistance < maxDistance && fingerClose && canChange)
		{
			buttonImage.color = GetImageColour();
		}

		if (!fingerClose)
		{
			buttonImage.color = originalColor;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "finger")
		{
			Debug.Log("Finger collided with collider");
			fingerClose = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "finger")
		{
			fingerClose = false;
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
