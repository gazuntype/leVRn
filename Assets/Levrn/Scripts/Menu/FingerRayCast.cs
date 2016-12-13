using UnityEngine;
using System.Collections;

public class FingerRayCast : MonoBehaviour
{
	// Use this for initialization
	GameObject[] functionButton;
	GameObject[] menuButton;
	IEnumerator buttonCoroutine;

	void OnEnable()
	{
		buttonCoroutine = CheckButtons();
		StartCoroutine(buttonCoroutine);
	}

	// Update is called once per frame
	void Update()
	{
		RaycastFinger();
	}

	void RaycastFinger()
	{
		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.up * 10f, Color.red, 0);
		if (Physics.Raycast(transform.position, transform.up * 10f, out hit))
		{
			if (hit.collider.gameObject.tag == "functionButton")
			{
				Animator anim;
				anim = hit.collider.gameObject.GetComponent<Animator>();
				anim.SetBool("isHover", true);
			}
			else {
				foreach (GameObject b in functionButton)
				{
					Animator anim;
					anim = b.GetComponent<Animator>();
					if (anim.isInitialized)
					{
						anim.SetBool("isHover", false);
					}
				}
			}
			if (hit.collider.gameObject.tag == "menuButton")
			{
				Debug.Log("I hit a menu button");
				Animator anim;
				anim = hit.collider.gameObject.GetComponent<Animator>();
				anim.SetBool("isHovering", true);
			}
			else {
				foreach (GameObject b in menuButton)
				{
					Animator anim;
					anim = b.GetComponent<Animator>();
					if (anim.isInitialized)
					{
						anim.SetBool("isHovering", false);
					}
				}
			}
		}
		else {
			foreach (GameObject b in menuButton)
			{
				Animator anim;
				anim = b.GetComponent<Animator>();
				if (anim.isInitialized)
				{
					anim.SetBool("isHovering", false);
				}
			}
			foreach (GameObject b in functionButton)
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
		functionButton = GameObject.FindGameObjectsWithTag("functionButton");
		menuButton = GameObject.FindGameObjectsWithTag("menuButton");
		yield return new WaitForSeconds(1);
	}
}
