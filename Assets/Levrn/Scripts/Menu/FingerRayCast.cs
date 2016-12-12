using UnityEngine;
using System.Collections;

public class FingerRayCast : MonoBehaviour {
	// Use this for initialization
	GameObject[] button;
	IEnumerator buttonCoroutine;

	void OnEnable () {
		buttonCoroutine = CheckButtons();
		StartCoroutine(buttonCoroutine);
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
				Animator anim;
				anim = hit.collider.gameObject.GetComponent<Animator>();
				anim.SetBool("isHover", true);
			}
			else {
				foreach (GameObject b in button)
				{
					Animator anim;
					anim = b.GetComponent<Animator>();
					anim.SetBool("isHover", false);
				}
			}
		}
		else {
			foreach (GameObject b in button)
			{
				Animator anim;
				anim = b.GetComponent<Animator>();
				if (anim.isInitialized)
				{
					anim.SetBool("isHover", false);
				}
			}
		}
	}

	IEnumerator CheckButtons()
	{
		button = GameObject.FindGameObjectsWithTag("button");
		Debug.Log(button);
		yield return new WaitForSeconds(1);
	}
}
