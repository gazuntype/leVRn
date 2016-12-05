using UnityEngine;
using System.Collections;

public class MenuSpawn : MonoBehaviour
{
	public Transform leftHandMenu;
	public Transform rightHandMenu;
	public Transform leftPalm;
	public Transform rightPalm;
	public Transform mainCamera;
	public Transform dataTracker;
	Vector3 trackedTransform;
	int trackedData;
	// Use this for initialization
	void Start()
	{
		leftHandMenu.gameObject.SetActive(false);
		rightHandMenu.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		trackedTransform = dataTracker.position;
		trackedData = (int)trackedTransform.x;
		if (trackedData == 1)
		{
			SpawnLeftHandMenu();
		}
		else if (trackedData == 2)
		{
			SpawnRightHandMenu();
		}
		else
		{
			rightHandMenu.gameObject.SetActive(false);
			leftHandMenu.gameObject.SetActive(false);
		}
	}

	void SpawnLeftHandMenu()
	{
		leftHandMenu.gameObject.SetActive(true);
		leftHandMenu.position = leftPalm.position + new Vector3(0, 0, 0.1f);
		foreach (Transform child in leftHandMenu)
		{
			child.eulerAngles = new Vector3(0, leftPalm.eulerAngles.y, 0);
		}
	}

	void SpawnRightHandMenu()
	{
		rightHandMenu.gameObject.SetActive(true);
		rightHandMenu.position = rightPalm.position + new Vector3(0, 0, 0.1f);
		foreach (Transform child in rightHandMenu)
		{
			child.eulerAngles = new Vector3(0, rightPalm.eulerAngles.y, 0);
		}
	}
}
