using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

	public GameObject player;
	public GameObject warpEffect;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowLight()
	{
		if (NetworkControl.isExploring)
		{
			warpEffect.GetComponent<ParticleSystem>().Play();
		}
	}

	public void TeleportUser()
	{

	}

	public void OffLight()
	{
		if (NetworkControl.isExploring)
		{
			warpEffect.GetComponent<ParticleSystem>().Stop();
		}
	}
}
