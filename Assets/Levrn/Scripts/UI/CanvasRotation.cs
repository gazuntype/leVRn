using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
	public GameObject player;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 mirrorTransform;
		mirrorTransform = transform.position + (transform.position - player.transform.position);
		transform.LookAt(mirrorTransform);
	}
}
