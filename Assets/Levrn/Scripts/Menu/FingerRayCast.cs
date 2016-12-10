using UnityEngine;
using System.Collections;

public class FingerRayCast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastFinger();
	}

	void RaycastFinger()
	{
		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.up * 10f, Color.red, 0);
		if (Physics.Raycast(transform.position, transform.up * 10f, out hit))
		{
			if (hit.collider.gameObject.tag == "button")
			{
				Debug.Log(hit.collider.gameObject.name);
				hit.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
			}
		}
	}
}
