using UnityEngine;
using System.Collections;

public class FunctionSpawn : MonoBehaviour
{
	public Transform[] functionButtons;
	public Transform functionPlacer;
	public Transform mainCamera;
	Transform dataTracker;
	Vector3 trackedTransform;
	int trackedData;
	// Use this for initialization
	void Start()
	{
		dataTracker = GameObject.Find("DataTracker").GetComponent<Transform>();
		foreach (Transform g in functionButtons)
		{
			g.gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
	{
		trackedTransform = dataTracker.position;
		trackedData = (int)trackedTransform.x;
		if (trackedData == 3)
		{
			foreach (Transform g in functionButtons)
			{
				g.gameObject.SetActive(true);
			}
			for (int i = 0; i < 5; i++)
			{
				float spacingX = 0.03f;
				float spacingY = 0.01f;
				functionButtons[i].position = functionPlacer.position + new Vector3(-spacingX * i, -(spacingY * i * i), 0);
				functionButtons[i].LookAt(mainCamera);
			}
		}
		else {
			foreach (Transform g in functionButtons)
			{
				g.gameObject.SetActive(false);
			}
		}
	}
}
