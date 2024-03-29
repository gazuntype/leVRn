﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

	public GameObject player;
	public GameObject warpEffect;

	[HideInInspector]
	public static string currentTeleportPad;

	[HideInInspector]
	public static bool isOutside = false;

	private ParticleSystem playerWarp;
	// Use this for initialization
	void Start () {
		playerWarp = player.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate()
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
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
		StartCoroutine(TeleportEffect());
	}

	IEnumerator TeleportEffect()
	{
		playerWarp.Play();
		yield return new WaitForSeconds(1f);
		playerWarp.Stop();
		player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
		if (tag == "tentPads")
		{
			currentTeleportPad = gameObject.name;
		}
		isOutside = true;
	}

	public void OffLight()
	{
		if (NetworkControl.isExploring)
		{
			warpEffect.GetComponent<ParticleSystem>().Stop();
		}
	}
}
